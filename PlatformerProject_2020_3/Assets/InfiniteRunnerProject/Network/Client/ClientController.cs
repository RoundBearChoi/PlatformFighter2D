using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Network;

namespace RB.Client
{
    public class ClientController : MonoBehaviour
    {
        readonly int _port = 26950;

        public static int dataBufferSize = 4096;

        public int myId = 0;
        public ClientTCP clientTCP;
        public ClientUDP clientUDP;

        public delegate void PacketHandler(Packet packet);
        public static Dictionary<int, PacketHandler> packetHandlers;

        private void Awake()
        {
            SetupTCPUDP();
        }

        public void SetupTCPUDP()
        {
            clientTCP = new ClientTCP();
            clientUDP = new ClientUDP(ClientManager.CURRENT.GetHostIP(), _port);
        }

        public void ConnectToServer(string ip)
        {
            InitClientData();

            Debug.Log("attempting to connect at: " + ip + "  port: " + _port);
            clientTCP.Connect(ip, dataBufferSize, _port);
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

        private void OnApplicationQuit()
        {
            if (ClientManager.CURRENT != null)
            {
                ClientManager.CURRENT.DisconnectClient();
            }
        }
    }
}