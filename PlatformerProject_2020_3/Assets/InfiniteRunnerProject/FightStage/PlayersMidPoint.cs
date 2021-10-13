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
            if (_player0.unitData.hp > 0 && _player1.unitData.hp > 0)
            {
                Vector3 dist = _player1.transform.position - _player0.transform.position;
                dist *= 0.5f;

                _obj.transform.position = _player0.transform.position + dist;
            }
            else
            {
                if (_player0.unitData.hp > 0)
                {
                    _obj.transform.position = Vector3.Lerp(_obj.transform.position, _player0.transform.position, 0.01f);
                }
                else if (_player1.unitData.hp > 0)
                {
                    _obj.transform.position = Vector3.Lerp(_obj.transform.position, _player1.transform.position, 0.01f);
                }
            }
        }
    }
}