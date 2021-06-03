using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Units
    {
        private List<Unit> _listUnits = new List<Unit>();
        private List<UnitCreator> _listUnitCreators = new List<UnitCreator>();

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
            foreach(Unit unit in _listUnits)
            {
                if (unit is T)
                {
                    return unit;
                }
            }

            return null;
        }

        public void ProcessCreators()
        {
            foreach (UnitCreator creator in _listUnitCreators)
            {
                Unit unit = creator.GetUnit();
                _listUnits.Add(unit);
            }

            _listUnitCreators.Clear();
        }

        public void OnFixedUpdate()
        {
            //main update
            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                _listUnits[i].spriteAnimations.MatchAnimationToState();
                _listUnits[i].OnFixedUpdate();
                _listUnits[i].ProcessDamage();
            }

            //temp
            //destroying units with 0 health
            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                if (_listUnits[i].unitData.health <= 0f)
                {
                    GameObject.Destroy(_listUnits[i].gameObject);
                    _listUnits.RemoveAt(i);
                }
            }
        }
    }
}