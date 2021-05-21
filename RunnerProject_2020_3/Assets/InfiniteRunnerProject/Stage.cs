using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Stage : MonoBehaviour
    {
        public Units units = new Units();

        protected GameInitializer _gameIntializer = null;
        protected List<UnitCreator> _listUnitCreators = new List<UnitCreator>();

        public virtual void Init()
        {

        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void SetInitializer(GameInitializer gameInitializer)
        {
            _gameIntializer = gameInitializer;
        }

        public virtual void CreateUnits()
        {
            foreach(UnitCreator creator in _listUnitCreators)
            {
                Unit unit = creator.GetUnit();
                units.AddUnit(unit);
            }

            _listUnitCreators.Clear();
        }
    }
}