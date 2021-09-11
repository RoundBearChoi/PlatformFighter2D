using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Network;

namespace RB.Client
{
    public class ClientSend : MonoBehaviour
    {
        /// <summary>Sends a packet to the server via TCP.</summary>
        /// <param name="_packet">The packet to send to the sever.</param>
        private static void SendTCPData(Packet _packet)
        {
            _packet.WriteLength();
            Client.instance.tcp.SendData(_packet);
        }

        /// <summary>Sends a packet to the server via UDP.</summary>
        /// <param name="_packet">The packet to send to the sever.</param>
        private static void SendUDPData(Packet _packet)
        {
            _packet.WriteLength();
            Client.instance.udp.SendData(_packet);
        }

        /// <summary>Lets the server know that the welcome message was received.</summary>
        public static void WelcomeReceived()
        {
            using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
            {
                _packet.Write(Client.instance.myId);

                string name = BaseClientControl.CURRENT.GetUserName();

                if (string.IsNullOrEmpty(name))
                {
                    name = "client";
                }

                _packet.Write(name);

                SendTCPData(_packet);
            }
        }

        /// <summary>Sends player input to the server.</summary>
        /// <param name="_inputs"></param>
        public static void SendClientInput(bool[] inputs)
        {
            using (Packet packet = new Packet((int)ClientPackets.client_input))
            {
                packet.Write(inputs.Length);
                
                for (int i = 0; i < inputs.Length; i++)
                {
                    packet.Write(inputs[i]);
                }

                SendUDPData(packet);
            }
        }
    }
}