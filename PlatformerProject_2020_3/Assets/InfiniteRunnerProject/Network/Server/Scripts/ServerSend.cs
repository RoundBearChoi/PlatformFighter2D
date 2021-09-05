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
        private void SendTCPData(int _toClient, Packet _packet)
        {
            _packet.WriteLength();
            BaseNetworkControl.CURRENT.server.clients[_toClient].tcp.SendData(_packet);
        }

        /// <summary>Sends a packet to all clients via UDP.</summary>
        /// <param name="_packet">The packet to send.</param>
        private void SendUDPDataToAll(Packet _packet)
        {
            _packet.WriteLength();

            for (int i = 0; i < BaseNetworkControl.CURRENT.server.clients.Length; i++)
            {
                BaseNetworkControl.CURRENT.server.clients[i].udp.SendData(_packet);
            }
        }

        /// <summary>Sends a packet to all clients except one via UDP.</summary>
        /// <param name="_exceptClient">The client to NOT send the data to.</param>
        /// <param name="_packet">The packet to send.</param>
        private void SendUDPDataToAll(int _exceptClient, Packet _packet)
        {
            _packet.WriteLength();

            for (int i = 0; i < BaseNetworkControl.CURRENT.server.clients.Length; i++)
            {
                if (i != _exceptClient)
                {
                    BaseNetworkControl.CURRENT.server.clients[i].udp.SendData(_packet);
                }
            }
        }

        /// <summary>Sends a welcome message to the given client.</summary>
        /// <param name="_toClient">The client to send the packet to.</param>
        /// <param name="_msg">The message to send.</param>
        public void Welcome(int _toClient, string _msg)
        {
            using (Packet _packet = new Packet((int)ServerPackets.welcome))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);

                SendTCPData(_toClient, _packet);
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