using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Units
    {
        private List<Unit> _listUnits = new List<Unit>();

        public void AddUnit(Unit unit)
        {
            _listUnits.Add(unit);
        }

        public void OnFixedUpdate()
        {
            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                _listUnits[i].MatchAnimationToState();
                _listUnits[i].OnFixedUpdate();

                if (_listUnits[i].collisionDetector != null)
                {
                    bool clear = false;

                    foreach (GameObject obj in _listUnits[i].collisionDetector.listCollidedGameObjects)
                    {
                        Debugger.Log(_listUnits[i].gameObject.name + " detected collision");
                        _listUnits[i].OnCollision();
                        clear = true;
                    }

                    if (clear)
                    {
                        _listUnits[i].collisionDetector.listCollidedGameObjects.Clear();
                    }
                }

                if (_listUnits[i].unitData.destroy)
                {
                    GameObject.Destroy(_listUnits[i].gameObject);
                    _listUnits.RemoveAt(i);
                }
            }
        }
    }
}