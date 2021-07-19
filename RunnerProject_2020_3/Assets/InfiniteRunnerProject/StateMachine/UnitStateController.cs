using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UnitStateController : IStateController<UnitState>
    {
        public UnitState currentUnitState = null;

        private Unit _unit = null;

        public UnitStateController(Unit unit)
        {
            _unit = unit;
        }

        public UnitState GetCurrentState()
        {
            return currentUnitState;
        }

        public void OnUpdate()
        {
            currentUnitState.OnUpdate();
        }

        public void OnFixedUpdate()
        {
            currentUnitState.OnFixedUpdate();
            currentUnitState.fixedUpdateCount++;
        }

        public void OnLateUpdate()
        {
            currentUnitState.OnLateUpdate();
        }

        public void SetNewState(UnitState newState)
        {
            currentUnitState = newState;
            currentUnitState.fixedUpdateCount = 0;
            currentUnitState.OnEnter();
        }

        public void TransitionToNextState()
        {
            if (_unit.unitData.listNextStates.Count > 0)
            {
                currentUnitState.OnExit();

                SetNewState(_unit.unitData.listNextStates[_unit.unitData.listNextStates.Count - 1]);
                _unit.unitData.listNextStates.Clear();
            }
        }
    }
}