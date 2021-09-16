using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Network;

namespace RB.Server
{
    public class ServerSend
    {
        private void SendTCPData(int toClient, Packet packet)
        {
            packet.WriteLength();

            ClientData clientData = ServerManager.CURRENT.server.connectedClients.GetClientData(toClient);
            clientData.serverTCP.SendData(packet);
        }

        private void SendTCPDataToAll(Packet packet)
        {
            packet.WriteLength();

            ClientData[] arr = ServerManager.CURRENT.server.connectedClients.GetAllClients();

            foreach(ClientData data in arr)
            {
                data.serverTCP.SendData(packet);
            }
        }

        private void SendUDPDataToAll(Packet packet)
        {
            packet.WriteLength();

            ClientData[] arr = ServerManager.CURRENT.server.connectedClients.GetAllClients();

            foreach (ClientData data in arr)
            {
                data.serverUDP.SendData(packet);
            }
        }

        public void Welcome(int toClient, string msg)
        {
            using (Packet packet = new Packet((int)ServerPackets.welcome))
            {
                packet.Write(msg);
                packet.Write(toClient);

                SendTCPData(toClient, packet);
            }
        }

        public void ClientsConnectionStatus()
        {
            using (Packet _packet = new Packet((int)ServerPackets.clients_connection_status))
            {
                Debugger.Log("--- clients status ---");
                ClientData[] clients = ServerManager.CURRENT.server.connectedClients.GetAllClients();
                RB.Client.ClientConnection[] connections = RB.Client.ClientConnection.GetData(clients);

                if (connections.Length == 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Debugger.Log("client " + connections[i].mIndex + ": " + connections[i].mConnected);
                        _packet.Write(connections[i].mConnected);
                        _packet.Write(connections[i].mIndex);
                    }

                    SendTCPDataToAll(_packet);
                }
            }
        }

        public void EnterMultiplayerStage()
        {
            using (Packet packet = new Packet((int)ServerPackets.enter_multiplayer_stage))
            {
                SendTCPDataToAll(packet);
            }
        }

        public void SendPlayerPositions(PlayerDataset<PositionAndDirection> playerData)
        {
            using (Packet packet = new Packet((int)ServerPackets.player_data_positions))
            {
                int playerCount = playerData.playerCount;
                packet.Write(playerCount);

                for (int i = 0; i < playerData.listData.Count; i++)
                {
                    packet.Write(playerData.listIDs[i]);
                    packet.Write(playerData.listData[i].mPosition);
                    packet.Write(playerData.listData[i].mFacingRight);
                }

                SendTCPDataToAll(packet);
            }
        }

        public void SendPlayerUnitTypes(PlayerDataset<UnitType> playerData)
        {
            using (Packet packet = new Packet((int)ServerPackets.player_data_unit_types))
            {
                int playerCount = playerData.playerCount;
                packet.Write(playerCount);

                for (int i = 0; i < playerData.listData.Count; i++)
                {
                    packet.Write(playerData.listIDs[i]);
                    packet.Write((int)playerData.listData[i]);
                }

                SendTCPDataToAll(packet);
            }
        }

        public void SendPlayerSpriteType(int index, SpriteType spriteType)
        {
            using (Packet packet = new Packet((int)ServerPackets.player_data_sprite_type))
            {
                packet.Write(index);
                packet.Write((int)spriteType);

                SendTCPDataToAll(packet);
            }
        }
    }
}