using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    [System.Serializable]
    public class PlayerInServer
    {
        [SerializeField]
        Unit _unit = null;

        [SerializeField]
        int _playerIndex = 0;

        [SerializeField]
        Vector3 _position = new Vector3();

        [SerializeField]
        bool _facingRight = true;

        public PlayerInServer(Unit unit, int index)
        {
            _unit = unit;
            _playerIndex = index;
        }

        public void OnFixedUpdate()
        {
            _position = _unit.transform.position;
            _facingRight = _unit.facingRight;
        }

        public int GetIndex()
        {
            return _playerIndex;
        }

        public Vector3 GetPosition()
        {
            return _position;
        }

        public bool IsFacingRight()
        {
            return _facingRight;
        }

        public Unit GetUnit()
        {
            return _unit;
        }
    }
}