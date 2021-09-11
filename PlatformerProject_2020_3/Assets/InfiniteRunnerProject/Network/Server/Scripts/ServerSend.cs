using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Network;

namespace RB.Server
{
    public class ServerSend
    {
        /// <summary>Sends a packet to a client via TCP.</summary>
        /// <param name="_toClient">The client to send the packet the packet to.</param>
        /// <param name="_packet">The packet to send to the client.</param>
        private void SendTCPData(int toClient, Packet packet)
        {
            packet.WriteLength();

            ClientData clientData = BaseNetworkControl.CURRENT.server.connectedClients.GetClientData(toClient);
            clientData.tcp.SendData(packet);
        }

        private void SendTCPDataToAll(Packet packet)
        {
            packet.WriteLength();

            ClientData[] arr = BaseNetworkControl.CURRENT.server.connectedClients.GetAllClients();

            foreach(ClientData data in arr)
            {
                data.tcp.SendData(packet);
            }
        }

        /// <summary>Sends a packet to all clients via UDP.</summary>
        /// <param name="_packet">The packet to send.</param>
        private void SendUDPDataToAll(Packet packet)
        {
            packet.WriteLength();

            ClientData[] arr = BaseNetworkControl.CURRENT.server.connectedClients.GetAllClients();

            foreach (ClientData data in arr)
            {
                data.udp.SendData(packet);
            }
        }

        /// <summary>Sends a packet to all clients except one via UDP.</summary>
        /// <param name="_exceptClient">The client to NOT send the data to.</param>
        /// <param name="_packet">The packet to send.</param>
        //private void SendUDPDataToAll(int exceptClient, Packet packet)
        //{
        //    packet.WriteLength();
        //
        //    for (int i = 0; i < BaseNetworkControl.CURRENT.server.clients.Length; i++)
        //    {
        //        if (i != exceptClient)
        //        {
        //            BaseNetworkControl.CURRENT.server.clients[i].udp.SendData(packet);
        //        }
        //    }
        //}

        /// <summary>Sends a welcome message to the given client.</summary>
        /// <param name="_toClient">The client to send the packet to.</param>
        /// <param name="_msg">The message to send.</param>
        public void Welcome(int toClient, string msg)
        {
            using (Packet packet = new Packet((int)ServerPackets.welcome))
            {
                packet.Write(msg);
                packet.Write(toClient);

                SendTCPData(toClient, packet);
            }
        }

        public void ClientsConnectionStatus(int connectedPlayerIndex)
        {
            //using (Packet _packet = new Packet((int)ServerPackets.clients_connection_status))
            //{
            //    ClientData[] clients = BaseNetworkControl.CURRENT.server.connectedClients.GetAllClients();
            //    
            //    for (int i = 0; i < clients.Length; i++)
            //    {
            //        _packet.Write(clients[i]);
            //    }
            //    
            //    SendTCPDataToAll(_packet);
            //}
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

        /// <summary>Tells a client to spawn a player.</summary>
        /// <param name="_toClient">The client that should spawn the player.</param>
        /// <param name="_player">The player to spawn.</param>
        //public void SpawnPlayer(int _toClient, PlayerData _player)
        //{
        //    using (Packet _packet = new Packet((int)ServerPackets.spawnPlayer))
        //    {
        //        _packet.Write(_player.id);
        //        _packet.Write(_player.username);
        //        _packet.Write(_player.transform.position);
        //        _packet.Write(_player.transform.rotation);
        //    
        //        SendTCPData(_toClient, _packet);
        //    }
        //}

        /// <summary>Sends a player's updated position to all clients.</summary>
        /// <param name="_player">The player whose position to update.</param>
        //public void PlayerPosition(PlayerData _player)
        //{
        //    using (Packet _packet = new Packet((int)ServerPackets.playerPosition))
        //    {
        //        _packet.Write(_player.id);
        //        _packet.Write(_player.transform.position);
        //
        //        SendUDPDataToAll(_packet);
        //    }
        //}

        /// <summary>Sends a player's updated rotation to all clients except to himself (to avoid overwriting the local player's rotation).</summary>
        /// <param name="_player">The player whose rotation to update.</param>
        //public void PlayerRotation(PlayerData _player)
        //{
        //    using (Packet _packet = new Packet((int)ServerPackets.playerRotation))
        //    {
        //        _packet.Write(_player.id);
        //        _packet.Write(_player.transform.rotation);
        //
        //        SendUDPDataToAll(_player.id, _packet);
        //    }
        //}
    }
}