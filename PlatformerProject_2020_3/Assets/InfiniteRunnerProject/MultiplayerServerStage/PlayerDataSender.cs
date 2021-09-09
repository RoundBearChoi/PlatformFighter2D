using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    [System.Serializable]
    public class PlayerDataSender
    {
        public ServerPlayer[] _activePlayers = null;

        public PlayerDataSender()
        {
            _activePlayers = new ServerPlayer[4];


        }

        public void OnFixedUpdate()
        {

        }
    }
}