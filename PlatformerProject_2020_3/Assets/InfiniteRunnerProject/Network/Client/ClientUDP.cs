using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class ClientUDP
    {
        public System.Net.Sockets.UdpClient socket;
        public System.Net.IPEndPoint endPoint;

        public ClientUDP(string ip, int port)
        {
            endPoint = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(ip), port);
        }

        public void Connect(int _localPort)
        {
            socket = new System.Net.Sockets.UdpClient(_localPort);

            socket.Connect(endPoint);
            socket.BeginReceive(ReceiveCallback, null);

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
                if (socket != null)
                {
                    socket.BeginSend(packet.ToArray(), packet.Length(), null, null);
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

            RB.Network.ThreadManager.ExecuteOnMainThread(() =>
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

            endPoint = null;
            socket = null;
        }
    }
}