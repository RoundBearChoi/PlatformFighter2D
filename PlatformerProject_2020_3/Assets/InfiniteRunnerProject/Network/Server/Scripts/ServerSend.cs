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

            BaseNetworkControl.CURRENT.server.clients[toClient].tcp.SendData(packet);
        }

        private void SendTCPDataToAll(Packet packet)
        {
            packet.WriteLength();

            for (int i = 0; i < BaseNetworkControl.CURRENT.server.clients.Length; i++)
            {
                BaseNetworkControl.CURRENT.server.clients[i].tcp.SendData(packet);
            }
        }

        /// <summary>Sends a packet to all clients via UDP.</summary>
        /// <param name="_packet">The packet to send.</param>
        private void SendUDPDataToAll(Packet packet)
        {
            packet.WriteLength();

            for (int i = 0; i < BaseNetworkControl.CURRENT.server.clients.Length; i++)
            {
                BaseNetworkControl.CURRENT.server.clients[i].udp.SendData(packet);
            }
        }

        /// <summary>Sends a packet to all clients except one via UDP.</summary>
        /// <param name="_exceptClient">The client to NOT send the data to.</param>
        /// <param name="_packet">The packet to send.</param>
        private void SendUDPDataToAll(int exceptClient, Packet packet)
        {
            packet.WriteLength();

            for (int i = 0; i < BaseNetworkControl.CURRENT.server.clients.Length; i++)
            {
                if (i != exceptClient)
                {
                    BaseNetworkControl.CURRENT.server.clients[i].udp.SendData(packet);
                }
            }
        }

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
            using (Packet _packet = new Packet((int)ServerPackets.clients_connection_status))
            {
                bool[] clients = new bool[3];

                for (int i = 0; i < BaseNetworkControl.CURRENT.server.clients.Length; i++)
                {
                    if (BaseNetworkControl.CURRENT.server.clients[i].tcp.socket != null)
                    {
                        Debugger.Log("player " + i + " connection: TRUE");
                        clients[i] = true;
                    }
                    else
                    {
                        Debugger.Log("player " + i + " connection: FALSE");
                        clients[i] = false;
                    }
                }

                for (int i = 0; i < clients.Length; i++)
                {
                    _packet.Write(clients[i]);
                }

                SendTCPDataToAll(_packet);
            }
        }

        public void EnterMultiplayerStage()
        {
            using (Packet _packet = new Packet((int)ServerPackets.enter_multiplayer_stage))
            {
                SendTCPDataToAll(_packet);
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