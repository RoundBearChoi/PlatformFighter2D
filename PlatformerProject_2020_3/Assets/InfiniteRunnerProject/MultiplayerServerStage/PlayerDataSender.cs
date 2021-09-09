using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    [System.Serializable]
    public class PlayerDataSender
    {
        [SerializeField]
        List<ServerPlayer> _playersOnServer = null;

        public PlayerDataSender()
        {
            _playersOnServer = new List<ServerPlayer>();
        }

        public void AddUnit(Unit unit, int index)
        {
            _playersOnServer.Add(new ServerPlayer(unit, index));
        }

        public void OnFixedUpdate()
        {
            foreach(ServerPlayer player in _playersOnServer)
            {
                player.OnFixedUpdate();
            }
        }
    }
}