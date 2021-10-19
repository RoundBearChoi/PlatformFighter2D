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

            if (currentUnitState.fixedUpdateCount >= uint.MaxValue - 1)
            {
                currentUnitState.fixedUpdateCount = 0;
            }
        }

        public void OnLateUpdate()
        {
            currentUnitState.OnLateUpdate();
        }

        public void SetNewState(Unit unit, UnitState newState)
        {
            currentUnitState = newState;
            currentUnitState.fixedUpdateCount = 0;
            currentUnitState.SetOwnerUnit(unit);
            currentUnitState.OnEnter();
        }

        public void TransitionToNextState()
        {
            if (_unit.listNextStates.Count > 0)
            {
                currentUnitState.OnExit();

                SetNewState(_unit, _unit.listNextStates[0]);

                if (_unit.listNextStates[0].disallowTransitionQueue)
                {
                    _unit.listNextStates.Clear();
                }
                else
                {
                    _unit.listNextStates.RemoveAt(0);
                }
            }
        }
    }
}