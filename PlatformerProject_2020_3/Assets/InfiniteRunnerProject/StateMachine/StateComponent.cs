using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class StateComponent
    {
        //protected Unit _unit = null;
        protected UnitState _unitState = null;

        public Unit UNIT
        {
            get
            {
                return _unitState.OWNER_UNIT;
            }
        }

        public UnitPhysicsData UNIT_DATA
        {
            get
            {
                return _unitState.OWNER_UNIT.unitData;
            }
        }

        public virtual void OnUpdate()
        {

        }
        public virtual void OnFixedUpdate()
        {

        }
    }
}