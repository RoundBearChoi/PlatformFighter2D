using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using RB.Network;

namespace RB.Client
{
    public class Client : MonoBehaviour
    {
        readonly int _port = 26950;

        public static Client instance;
        public static int dataBufferSize = 4096;

        public int myId = 0;
        public TCP tcp;
        public UDP udp;

        private delegate void PacketHandler(Packet _packet);
        private static Dictionary<int, PacketHandler> packetHandlers;

        private void Awake()
        {
            instance = this;
            SetupTCPUDP();
        }

        public void SetupTCPUDP()
        {
            tcp = new TCP();
            udp = new UDP(ClientControl.CURRENT.GetHostIP());
        }

        private void OnApplicationQuit()
        {
            Disconnect();
        }

        public void ConnectToServer(string ip)
        {
            InitClientData();

            Debug.Log("attempting to connect at: " + ip + "  port: " + _port);
            tcp.Connect(ip);
        }

        public class TCP
        {
            public TcpClient socket;

            private NetworkStream stream;
            private Packet receivedData;
            private byte[] receiveBuffer;

            public void Connect(string ip)
            {
                socket = new TcpClient
                {
                    ReceiveBufferSize = dataBufferSize,
                    SendBufferSize = dataBufferSize
                };

                receiveBuffer = new byte[dataBufferSize];
                socket.BeginConnect(ip, instance._port, ConnectCallback, socket);
            }

            private void ConnectCallback(IAsyncResult _result)
            {
                try
                {
                    socket.EndConnect(_result);

                    if (!socket.Connected)
                    {
                        return;
                    }

                    stream = socket.GetStream();

                    receivedData = new Packet();

                    stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
                }
                catch(Exception e)
                {
                    Debug.Log("attempt failed: " + e);

                    ThreadManager.ExecuteOnMainThread(() =>
                    {
                        ClientControl.CURRENT.ShowEnterIPUI();
                        ClientControl.CURRENT.QueueConnectionFailedMessage();
                    });
                }
            }

            public void SendData(Packet _packet)
            {
                try
                {
                    if (socket != null)
                    {
                        stream.BeginWrite(_packet.ToArray(), 0, _packet.Length(), null, null); // Send data to server
                    }
                }
                catch (Exception _ex)
                {
                    Debug.Log($"Error sending data to server via TCP: {_ex}");
                }
            }

            private void ReceiveCallback(IAsyncResult _result)
            {
                try
                {
                    int _byteLength = stream.EndRead(_result);
                    if (_byteLength <= 0)
                    {
                        instance.Disconnect();
                        return;
                    }

                    byte[] _data = new byte[_byteLength];
                    Array.Copy(receiveBuffer, _data, _byteLength);

                    receivedData.Reset(HandleData(_data)); // Reset receivedData if all data was handled
                    stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
                }
                catch
                {
                    Disconnect();
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
                            packetHandlers[_packetId](_packet); // Call appropriate method to handle the packet
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

            private void Disconnect()
            {
                instance.Disconnect();

                stream = null;
                receivedData = null;
                receiveBuffer = null;
                socket = null;
            }
        }

        public class UDP
        {
            public UdpClient socket;
            public IPEndPoint endPoint;

            public UDP(string ip)
            {
                endPoint = new IPEndPoint(IPAddress.Parse(ip), instance._port);
            }

            public void Connect(int _localPort)
            {
                socket = new UdpClient(_localPort);

                socket.Connect(endPoint);
                socket.BeginReceive(ReceiveCallback, null);

                using (Packet _packet = new Packet())
                {
                    SendData(_packet);
                }
            }

            public void SendData(Packet _packet)
            {
                try
                {
                    _packet.InsertInt(instance.myId);
                    if (socket != null)
                    {
                        socket.BeginSend(_packet.ToArray(), _packet.Length(), null, null);
                    }
                }
                catch (Exception _ex)
                {
                    Debug.Log($"Error sending data to server via UDP: {_ex}");
                }
            }

            private void ReceiveCallback(IAsyncResult _result)
            {
                try
                {
                    byte[] _data = socket.EndReceive(_result, ref endPoint);
                    socket.BeginReceive(ReceiveCallback, null);

                    if (_data.Length < 4)
                    {
                        instance.Disconnect();
                        return;
                    }

                    HandleData(_data);
                }
                catch
                {
                    Disconnect();
                }
            }

            private void HandleData(byte[] data)
            {
                using (Packet packet = new Packet(data))
                {
                    int packetLength = packet.ReadInt();
                    data = packet.ReadBytes(packetLength);
                }

                ThreadManager.ExecuteOnMainThread(() =>
                {
                    using (Packet packet = new Packet(data))
                    {
                        int packetID = packet.ReadInt();

                        if (packetHandlers.ContainsKey(packetID))
                        {
                            packetHandlers[packetID](packet); // Call appropriate method to handle the packet
                        }
                        else
                        {
                            Debugger.Log("packet id not found: " + packetID);
                        }
                    }
                });
            }

            private void Disconnect()
            {
                instance.Disconnect();

                endPoint = null;
                socket = null;
            }
        }

        private void InitClientData()
        {
            packetHandlers = new Dictionary<int, PacketHandler>()
            {
                { (int)ServerPackets.welcome, ClientHandle.Welcome },
                
                {(int)ServerPackets.clients_connection_status, ClientHandle.ClientsConnectionStatus },
                {(int)ServerPackets.enter_multiplayer_stage, ClientHandle.EnterMultiplayerStage },
                {(int)ServerPackets.player_data_unit_types, ClientHandle.InitOnPlayerUnitTypes },
                {(int)ServerPackets.player_data_positions, ClientHandle.UpdateOnPlayerPositions },
                {(int)ServerPackets.player_data_sprite_type, ClientHandle.UpdateOnPlayerSpriteType},
            };

            Debug.Log("initialized clientdata");
        }

        private void Disconnect()
        {
            if (tcp.socket != null)
            {
                if (tcp.socket.Connected)
                {
                    tcp.socket.Close();
                    udp.socket.Close();
                }
            }

            Debug.Log("Disconnected from server.");

            ThreadManager.ExecuteOnMainThread(() =>
            {
                SetupTCPUDP();
                ClientControl.CURRENT.ShowEnterIPUI();
            });
        }
    }
}