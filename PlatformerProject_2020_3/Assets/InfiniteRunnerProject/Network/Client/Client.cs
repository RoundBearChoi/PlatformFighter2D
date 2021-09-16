using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Network;

namespace RB.Client
{
    public class Client : MonoBehaviour
    {
        readonly int _port = 26950;

        public static Client instance;
        public static int dataBufferSize = 4096;

        public int myId = 0;
        public ClientTCP clientTCP;
        public ClientUDP clientUDP;

        public delegate void PacketHandler(Packet packet);
        public static Dictionary<int, PacketHandler> packetHandlers;

        private void Awake()
        {
            instance = this;
            SetupTCPUDP();
        }

        public void SetupTCPUDP()
        {
            clientTCP = new ClientTCP();
            clientUDP = new ClientUDP(ClientControl.CURRENT.GetHostIP());
        }

        private void OnApplicationQuit()
        {
            DisconnectClient();
        }

        public void ConnectToServer(string ip)
        {
            InitClientData();

            Debug.Log("attempting to connect at: " + ip + "  port: " + _port);
            clientTCP.Connect(ip, dataBufferSize, _port);
        }

        public class ClientUDP
        {
            public System.Net.Sockets.UdpClient socket;
            public System.Net.IPEndPoint endPoint;

            public ClientUDP(string ip)
            {
                endPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(ip), instance._port);
            }

            public void Connect(int _localPort)
            {
                socket = new System.Net.Sockets.UdpClient(_localPort);

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
                catch (System.Exception e)
                {
                    Debug.Log($"Error sending data to server via UDP: {e}");
                }
            }

            private void ReceiveCallback(System.IAsyncResult _result)
            {
                try
                {
                    byte[] _data = socket.EndReceive(_result, ref endPoint);
                    socket.BeginReceive(ReceiveCallback, null);

                    if (_data.Length < 4)
                    {
                        instance.DisconnectClient();
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
                instance.DisconnectClient();

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

        public void DisconnectClient()
        {
            if (clientTCP.socket != null)
            {
                if (clientTCP.socket.Connected)
                {
                    clientTCP.socket.Close();
                    clientUDP.socket.Close();
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