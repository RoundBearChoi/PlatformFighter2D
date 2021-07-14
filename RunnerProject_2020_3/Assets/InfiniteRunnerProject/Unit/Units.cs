using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Units
    {
        public static Units instance = null;
        public BaseMessageHandler unitsMessageHandler = null;

        private List<Unit> _listUnits = new List<Unit>();
        private List<BaseUnitCreator> _listUnitCreators = new List<BaseUnitCreator>();

        public Units()
        {
            instance = this;
            unitsMessageHandler = new UnitsMessageHandler(_listUnits);
        }

        public void AddCreator(BaseUnitCreator creator)
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
            foreach (BaseUnitCreator creator in _listUnitCreators)
            {
                creator.AddUnits(_listUnits);
            }

            _listUnitCreators.Clear();
        }

        public void OnUpdate()
        {
            foreach(Unit unit in _listUnits)
            {
                unit.OnUpdate();
            }
        }

        public void OnFixedUpdate()
        {
            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
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

                if (_listUnits[i].unitData.boxCollider2D != null)
                {
                    _listUnits[i].SetCurrentVelocity(_listUnits[i].unitData.boxCollider2D.attachedRigidbody.velocity);
                }

                _listUnits[i].OnFixedUpdate();

                //old code, can replaced by a message
                if (_listUnits[i].ProcessDamage())
                {

                }
            }

            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
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

            unitsMessageHandler.HandleMessages();
            unitsMessageHandler.ClearMessages();

            foreach (Unit unit in _listUnits)
            {
                if (unit.unitMessageHandler != null)
                {
                    unit.unitMessageHandler.HandleMessages();
                    unit.unitMessageHandler.ClearMessages();
                }
            }
        }
    }
}