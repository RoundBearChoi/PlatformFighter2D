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

        [SerializeField]
        Vector3 _position = new Vector3();

        public ServerPlayer(Unit unit, int index)
        {
            _unit = unit;
            _playerIndex = index;
        }

        public void OnFixedUpdate()
        {
            _position = _unit.transform.position;
        }

        public int GetIndex()
        {
            return _playerIndex;
        }

        public Vector3 GetPosition()
        {
            return _position;
        }
    }
}