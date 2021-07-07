using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Units
    {
        public static Units instance = null;

        private List<Unit> _listUnits = new List<Unit>();
        private List<UnitCreator> _listUnitCreators = new List<UnitCreator>();

        public Units()
        {
            instance = this;
        }

        public void AddCreator(UnitCreator creator)
        {
            _listUnitCreators.Add(creator);
        }

        public void AddUnit(Unit unit)
        {
            _listUnits.Add(unit);
        }

        public Unit GetUnit<T>()
        {
            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                if (_listUnits[i] is T)
                {
                    return _listUnits[i];
                }
            }

            return null;
        }

        public void ProcessCreators()
        {
            foreach (UnitCreator creator in _listUnitCreators)
            {
                creator.AddUnits(_listUnits);
            }

            _listUnitCreators.Clear();
        }

        public void OnFixedUpdate()
        {
            //main update
            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                if (_listUnits[i].unitData.spriteAnimations != null)
                {
                    _listUnits[i].unitData.spriteAnimations.MatchAnimationToState();
                }
                
                if (_listUnits[i].unitData.faceRight)
                {
                    if (_listUnits[i].transform.rotation.y != 0f)
                    {
                        _listUnits[i].transform.rotation = Quaternion.Euler(_listUnits[i].transform.rotation.x, 0f, _listUnits[i].transform.rotation.z);
                    }
                }
                else
                {
                    if (_listUnits[i].transform.rotation.y != 180f)
                    {
                        _listUnits[i].transform.rotation = Quaternion.Euler(_listUnits[i].transform.rotation.x, 180f, _listUnits[i].transform.rotation.z);
                    }
                }

                _listUnits[i].OnFixedUpdate();
                _listUnits[i].ProcessDamage();
            }

            //temp
            //destroying units with 0 health
            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                if (_listUnits[i].unitData.health <= 0)
                {
                    _listUnits[i].RunDeathAnimation();
                }

                if (_listUnits[i].destroy)
                {
                    GameObject.Destroy(_listUnits[i].gameObject);
                    _listUnits.RemoveAt(i);
                }
            }
        }

        public void OnLateUpdate()
        {
            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                _listUnits[i].OnLateUpdate();
            }
        }
    }
}