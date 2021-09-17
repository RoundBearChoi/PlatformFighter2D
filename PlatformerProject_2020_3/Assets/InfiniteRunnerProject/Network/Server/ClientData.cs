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

        public void Disconnect()
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