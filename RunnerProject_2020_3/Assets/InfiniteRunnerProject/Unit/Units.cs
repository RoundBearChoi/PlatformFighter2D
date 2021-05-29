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

        public Unit GetUnit(int index)
        {
            return _listUnits[index];
        }

        public void CreateUnits()
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
                _listUnits[i].MatchAnimationToState();
                _listUnits[i].OnFixedUpdate();
            }

            //destroy after update
            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                if (_listUnits[i].unitData.destroy)
                {
                    GameObject.Destroy(_listUnits[i].gameObject);
                    _listUnits.RemoveAt(i);
                }
            }
        }
    }
}