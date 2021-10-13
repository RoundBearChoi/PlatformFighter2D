using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class PlayersMidPoint
    {
        GameObject _obj = null;
        Unit _player0 = null;
        Unit _player1 = null;

        public PlayersMidPoint(GameObject obj, Unit player0, Unit player1)
        {
            _obj = obj;
            _player0 = player0;
            _player1 = player1;
        }

        public void OnFixedUpdate()
        {
            Vector3 dist = _player1.transform.position - _player0.transform.position;
            dist *= 0.5f;

            _obj.transform.position = _player0.transform.position + dist;
        }
    }
}