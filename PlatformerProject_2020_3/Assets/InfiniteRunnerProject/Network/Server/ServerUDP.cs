using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    public class ServerUDP
    {
        public System.Net.IPEndPoint ipEndPoint;

        int _clientID;

        public ServerUDP(int id)
        {
            _clientID = id;
        }

        public void Connect(System.Net.IPEndPoint ep)
        {
            ipEndPoint = ep;
        }

        public void SendUDP(RB.Network.Packet packet)
        {
            ServerManager.CURRENT.serverController.BeginServerUDPSend(ipEndPoint, packet);
        }

        public void HandleData(RB.Network.Packet packetData)
        {
            int packetLength = packetData.ReadInt();
            byte[] packetBytes = packetData.ReadBytes(packetLength);

            RB.Network.ThreadControl.ExecuteOnMainThread(() =>
            {
                using (RB.Network.Packet packet = new RB.Network.Packet(packetBytes))
                {
                    int packetId = packet.ReadInt();
                    ServerManager.CURRENT.serverController.packetHandlers[packetId](_clientID, packet);
                }
            });
        }
    }
}