using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class ClientUDP
    {
        System.Net.Sockets.UdpClient _socket;
        System.Net.IPEndPoint _endPoint;

        public System.Net.Sockets.UdpClient SOCKET
        {
            get
            {
                return _socket;
            }
        }
        
        public ClientUDP(string ip)
        {
            _endPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(ip), RB.Server.ServerController.PORT);
        }

        public void Connect(int _localPort)
        {
            _socket = new System.Net.Sockets.UdpClient(_localPort);

            _socket.Connect(_endPoint);
            _socket.BeginReceive(ReceiveCallback, null);

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
                if (_socket != null)
                {
                    _socket.BeginSend(packet.ToArray(), packet.Length(), null, null);
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
                byte[] _data = _socket.EndReceive(_result, ref _endPoint);
                _socket.BeginReceive(ReceiveCallback, null);

                if (_data.Length < 4)
                {
                    ClientManager.CURRENT.DisconnectClient();
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
                        ClientController.packetHandlers[packetID](packet); // Call appropriate method to handle the packet
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
            ClientManager.CURRENT.DisconnectClient();

            _endPoint = null;
            _socket = null;
        }
    }
}