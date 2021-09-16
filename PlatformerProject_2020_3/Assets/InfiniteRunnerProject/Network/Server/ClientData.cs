using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using RB.Network;

namespace RB.Server
{
    [Serializable]
    public class ClientData
    {
        public static int dataBufferSize = 4096;

        [SerializeField]
        string _name = string.Empty;

        public ServerTCP serverTCP;
        public ServerUDP serverUDP;

        [SerializeField]
        bool[] _inputs = null;

        public ClientData(int clientId)
        {
            serverTCP = new ServerTCP(clientId);
            serverUDP = new ServerUDP(clientId);
        }

        [System.Serializable]
        public class ServerTCP
        {
            [SerializeField]
            private int _id;

            public TcpClient socket;
            private NetworkStream stream;
            private Packet receivedData;
            private byte[] receiveBuffer;

            public ServerTCP(int id)
            {
                _id = id;
            }

            public int ID
            {
                get
                {
                    return _id;
                }
            }

            public void Connect(TcpClient incomingSocket)
            {
                socket = incomingSocket;
                socket.ReceiveBufferSize = dataBufferSize;
                socket.SendBufferSize = dataBufferSize;

                stream = socket.GetStream();

                receivedData = new Packet();
                receiveBuffer = new byte[dataBufferSize];

                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);

                ServerManager.CURRENT.serverSend.Welcome(_id, "Welcome to the server!");
                ServerManager.CURRENT.serverSend.ClientsConnectionStatus();
            }

            public void SendData(Packet _packet)
            {
                try
                {
                    if (socket != null)
                    {
                        stream.BeginWrite(_packet.ToArray(), 0, _packet.Length(), null, null); // Send data to appropriate client
                    }
                }
                catch (Exception _ex)
                {
                    Debug.Log($"Error sending data to player {_id} via TCP: {_ex}");
                }
            }

            private void ReceiveCallback(IAsyncResult _result)
            {
                try
                {
                    int _byteLength = stream.EndRead(_result);
                    if (_byteLength <= 0)
                    {
                        ClientData data = ServerManager.CURRENT.server.connectedClients.GetClientData(_id);
                        data.Disconnect();
                        return;
                    }

                    byte[] _data = new byte[_byteLength];
                    Array.Copy(receiveBuffer, _data, _byteLength);

                    receivedData.Reset(HandleData(_data)); // Reset receivedData if all data was handled
                    stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
                }
                catch (Exception _ex)
                {
                    Debug.Log($"Error receiving TCP data: {_ex}");

                    ClientData data = ServerManager.CURRENT.server.connectedClients.GetClientData(_id);
                    data.Disconnect();
                }
            }

            private bool HandleData(byte[] _data)
            {
                int _packetLength = 0;

                receivedData.SetBytes(_data);

                if (receivedData.UnreadLength() >= 4)
                {
                    // If client's received data contains a packet
                    _packetLength = receivedData.ReadInt();
                    if (_packetLength <= 0)
                    {
                        // If packet contains no data
                        return true; // Reset receivedData instance to allow it to be reused
                    }
                }

                while (_packetLength > 0 && _packetLength <= receivedData.UnreadLength())
                {
                    // While packet contains data AND packet data length doesn't exceed the length of the packet we're reading
                    byte[] _packetBytes = receivedData.ReadBytes(_packetLength);
                    ThreadManager.ExecuteOnMainThread(() =>
                    {
                        using (Packet _packet = new Packet(_packetBytes))
                        {
                            int _packetId = _packet.ReadInt();
                            ServerManager.CURRENT.server.packetHandlers[_packetId](_id, _packet); // Call appropriate method to handle the packet
                        }
                    });

                    _packetLength = 0; // Reset packet length
                    if (receivedData.UnreadLength() >= 4)
                    {
                        // If client's received data contains another packet
                        _packetLength = receivedData.ReadInt();
                        if (_packetLength <= 0)
                        {
                            // If packet contains no data
                            return true; // Reset receivedData instance to allow it to be reused
                        }
                    }
                }

                if (_packetLength <= 1)
                {
                    return true; // Reset receivedData instance to allow it to be reused
                }

                return false;
            }

            public void Disconnect()
            {
                socket.Close();
                stream = null;
                receivedData = null;
                receiveBuffer = null;
                socket = null;
            }
        }

        public class ServerUDP
        {
            public IPEndPoint endPoint;

            private int id;

            public ServerUDP(int _id)
            {
                id = _id;
            }

            public void Connect(IPEndPoint _endPoint)
            {
                endPoint = _endPoint;
            }

            public void SendData(Packet _packet)
            {
                ServerManager.CURRENT.server.SendUDPData(endPoint, _packet);
            }

            public void HandleData(Packet _packetData)
            {
                int _packetLength = _packetData.ReadInt();
                byte[] _packetBytes = _packetData.ReadBytes(_packetLength);

                ThreadManager.ExecuteOnMainThread(() =>
                {
                    using (Packet _packet = new Packet(_packetBytes))
                    {
                        int _packetId = _packet.ReadInt();
                        ServerManager.CURRENT.server.packetHandlers[_packetId](id, _packet); // Call appropriate method to handle the packet
                    }
                });
            }

            public void Disconnect()
            {
                endPoint = null;
            }
        }

        private void Disconnect()
        {
            Debug.Log($"{serverTCP.socket.Client.RemoteEndPoint} has disconnected.");

            serverTCP.Disconnect();
            serverUDP.Disconnect();

            ThreadManager.ExecuteOnMainThread(() =>
            {
                ServerManager.CURRENT.server.connectedClients.RemoveClient(this);
                ServerManager.CURRENT.serverSend.ClientsConnectionStatus();
            });
        }

        public void SetInput(bool[] inputs)
        {
            _inputs = inputs;
        }

        public void SetUserName(string name)
        {
            _name = name;
        }
    }
}