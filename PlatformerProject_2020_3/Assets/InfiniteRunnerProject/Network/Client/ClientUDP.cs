using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class ClientUDP
    {
        System.Net.Sockets.UdpClient _udpClient;
        System.Net.IPEndPoint _endPoint;

        public System.Net.Sockets.UdpClient SOCKET
        {
            get
            {
                return _udpClient;
            }
        }
        
        public ClientUDP(string ip)
        {
            _endPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(ip), RB.Server.ServerController.PORT);
        }

        public void Connect(int _localPort)
        {
            _udpClient = new System.Net.Sockets.UdpClient(_localPort);

            _udpClient.Connect(_endPoint);
            _udpClient.BeginReceive(ReceiveCallback, null);

            using (RB.Network.Packet packet = new RB.Network.Packet())
            {
                SendData(packet);
            }
        }

        public void SendData(RB.Network.Packet packet)
        {
            try
            {
                packet.InsertInt(ClientManager.CURRENT.clientController.myId);

                if (_udpClient != null)
                {
                    _udpClient.BeginSend(packet.ToArray(), packet.Length(), null, null);
                }
            }
            catch (System.Exception e)
            {
                Debug.Log("system error sending UDP to server: " + e);
            }
        }

        private void ReceiveCallback(System.IAsyncResult result)
        {
            try
            {
                byte[] arr = _udpClient.EndReceive(result, ref _endPoint);

                _udpClient.BeginReceive(ReceiveCallback, null);

                if (arr.Length < 4)
                {
                    Debugger.Log("received less than 4 bytes");

                    ClientManager.CURRENT.DisconnectClient();

                    return;
                }

                //Debugger.Log("receiving udp");

                HandleData(arr);
            }
            catch (System.Exception e)
            {
                Debugger.Log("system error on udpsend: " + e);

                ClientManager.CURRENT.DisconnectClient();
            }
        }

        private void HandleData(byte[] data)
        {
            using (RB.Network.Packet packet = new RB.Network.Packet(data))
            {
                int packetLength = packet.ReadInt();
                data = packet.ReadBytes(packetLength);
            }

            RB.Network.ThreadControl.ExecuteOnMainThread(() =>
            {
                using (RB.Network.Packet packet = new RB.Network.Packet(data))
                {
                    int packetID = packet.ReadInt();

                    if (ClientController.packetHandlers.ContainsKey(packetID))
                    {
                        ClientController.packetHandlers[packetID](packet);
                    }
                    else
                    {
                        Debugger.Log("packet id not found: " + packetID);
                    }
                }
            });
        }
    }
}