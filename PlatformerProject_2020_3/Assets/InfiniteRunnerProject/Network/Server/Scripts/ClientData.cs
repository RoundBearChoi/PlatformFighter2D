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
        string _name;

        public TCP tcp;
        public UDP udp;

        [SerializeField]
        bool[] _inputs;

        public ClientData(int _clientId)
        {
            tcp = new TCP(_clientId);
            udp = new UDP(_clientId);
        }

        [System.Serializable]
        public class TCP
        {
            [SerializeField]
            private int _id;

            public TcpClient socket;
            private NetworkStream stream;
            private Packet receivedData;
            private byte[] receiveBuffer;

            public TCP(int id)
            {
                _id = id;
            }

            /// <summary>Initializes the newly connected client's TCP-related info.</summary>
            /// <param name="_socket">The TcpClient instance of the newly connected client.</param>
            public void Connect(TcpClient _socket)
            {
                socket = _socket;
                socket.ReceiveBufferSize = dataBufferSize;
                socket.SendBufferSize = dataBufferSize;

                stream = socket.GetStream();

                receivedData = new Packet();
                receiveBuffer = new byte[dataBufferSize];

                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);

                BaseNetworkControl.CURRENT.serverSend.Welcome(_id, "Welcome to the server!");
                BaseNetworkControl.CURRENT.serverSend.ClientsConnectionStatus(_id);
            }

            /// <summary>Sends data to the client via TCP.</summary>
            /// <param name="_packet">The packet to send.</param>
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

            /// <summary>Reads incoming data from the stream.</summary>
            private void ReceiveCallback(IAsyncResult _result)
            {
                try
                {
                    int _byteLength = stream.EndRead(_result);
                    if (_byteLength <= 0)
                    {
                        BaseNetworkControl.CURRENT.server.clients[_id].Disconnect();
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
                    BaseNetworkControl.CURRENT.server.clients[_id].Disconnect();
                }
            }

            /// <summary>Prepares received data to be used by the appropriate packet handler methods.</summary>
            /// <param name="_data">The recieved data.</param>
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
                            BaseNetworkControl.CURRENT.server.packetHandlers[_packetId](_id, _packet); // Call appropriate method to handle the packet
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

            /// <summary>Closes and cleans up the TCP connection.</summary>
            public void Disconnect()
            {
                socket.Close();
                stream = null;
                receivedData = null;
                receiveBuffer = null;
                socket = null;
            }
        }

        public class UDP
        {
            public IPEndPoint endPoint;

            private int id;

            public UDP(int _id)
            {
                id = _id;
            }

            /// <summary>Initializes the newly connected client's UDP-related info.</summary>
            /// <param name="_endPoint">The IPEndPoint instance of the newly connected client.</param>
            public void Connect(IPEndPoint _endPoint)
            {
                endPoint = _endPoint;
            }

            /// <summary>Sends data to the client via UDP.</summary>
            /// <param name="_packet">The packet to send.</param>
            public void SendData(Packet _packet)
            {
                BaseNetworkControl.CURRENT.server.SendUDPData(endPoint, _packet);
            }

            /// <summary>Prepares received data to be used by the appropriate packet handler methods.</summary>
            /// <param name="_packetData">The packet containing the recieved data.</param>
            public void HandleData(Packet _packetData)
            {
                int _packetLength = _packetData.ReadInt();
                byte[] _packetBytes = _packetData.ReadBytes(_packetLength);

                ThreadManager.ExecuteOnMainThread(() =>
                {
                    using (Packet _packet = new Packet(_packetBytes))
                    {
                        int _packetId = _packet.ReadInt();
                        BaseNetworkControl.CURRENT.server.packetHandlers[_packetId](id, _packet); // Call appropriate method to handle the packet
                    }
                });
            }

            /// <summary>Cleans up the UDP connection.</summary>
            public void Disconnect()
            {
                endPoint = null;
            }
        }

        /// <summary>Sends the client into the game and informs other clients of the new player.</summary>
        /// <param name="_playerName">The username of the new player.</param>
        //public void SendIntoGame(string _playerName)
        //{
        //    playerData = NetworkManager.instance.InstantiatePlayer();
        //    
        //    playerData.Initialize(_id, _playerName);
        //
        //    // Send all players to the new player
        //    for (int i = 0; i < NetworkManager.instance.server.connectedClients.Length; i++)
        //    {
        //        if (NetworkManager.instance.server.connectedClients[i].playerData != null)
        //        {
        //            if (NetworkManager.instance.server.connectedClients[i]._id != _id)
        //            {
        //                NetworkManager.instance.serverSend.SpawnPlayer(_id, NetworkManager.instance.server.connectedClients[i].playerData);
        //            }
        //        }
        //    }
        //    
        //    // Send the new player to all players (including himself)
        //    for (int i = 0; i < NetworkManager.instance.server.connectedClients.Length; i++)
        //    {
        //        if (NetworkManager.instance.server.connectedClients[i].playerData != null)
        //        {
        //            NetworkManager.instance.serverSend.SpawnPlayer(NetworkManager.instance.server.connectedClients[i]._id, playerData);
        //        }
        //    }
        //}

        /// <summary>Disconnects the client and stops all network traffic.</summary>
        private void Disconnect()
        {
            Debug.Log($"{tcp.socket.Client.RemoteEndPoint} has disconnected.");

            ThreadManager.ExecuteOnMainThread(() =>
            {
                _name = "disconnected";
                _inputs = null;
            });

            tcp.Disconnect();
            udp.Disconnect();
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