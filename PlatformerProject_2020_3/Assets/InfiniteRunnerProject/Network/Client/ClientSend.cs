using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Network;

namespace RB.Client
{
    public class ClientSend : MonoBehaviour
    {
        private static void SendTCPData(Packet _packet)
        {
            _packet.WriteLength();
            ClientManager.CURRENT.clientController.clientTCP.SendData(_packet);
        }

        private static void SendUDPData(Packet _packet)
        {
            _packet.WriteLength();
            ClientManager.CURRENT.clientController.clientUDP.SendData(_packet);
        }

        public static void WelcomeReceived()
        {
            using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
            {
                _packet.Write(ClientManager.CURRENT.clientController.myId);

                string name = ClientManager.CURRENT.GetUserName();

                if (string.IsNullOrEmpty(name))
                {
                    name = "client";
                }

                _packet.Write(name);

                SendTCPData(_packet);
            }
        }

        public static void SendClientInput(bool[] inputs)
        {
            using (Packet packet = new Packet((int)ClientPackets.client_input))
            {
                packet.Write(inputs.Length);
                
                for (int i = 0; i < inputs.Length; i++)
                {
                    packet.Write(inputs[i]);
                }

                SendTCPData(packet);
            }

            using(Packet packet = new Packet((int)ClientPackets.udp_check))
            {
                SendUDPData(packet);
            }
        }
    }
}