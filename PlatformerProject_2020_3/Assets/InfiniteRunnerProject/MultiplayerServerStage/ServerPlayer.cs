using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    [System.Serializable]
    public class ServerPlayer
    {
        [SerializeField]
        Unit _unit = null;

        [SerializeField]
        int _playerIndex = 0;
    }
}