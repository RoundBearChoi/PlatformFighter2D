using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    [System.Serializable]
    public class PlayerPositionSender
    {
        public ServerPlayer[] _activePlayers = null;

        public PlayerPositionSender()
        {
            _activePlayers = new ServerPlayer[4];


        }
    }
}