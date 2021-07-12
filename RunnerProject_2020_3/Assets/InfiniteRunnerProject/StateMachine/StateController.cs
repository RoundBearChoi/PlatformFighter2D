using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StateController : IStateController
    {
        public State currentState = null;

        private Unit _unit = null;

        public StateController(Unit unit)
        {
            _unit = unit;
        }

        public void OnFixedUpdate()
        {
            currentState.OnFixedUpdate();
            currentState.updateCount++;
        }

        public void OnLateUpdate()
        {
            currentState.OnLateUpdate();
        }

        public void SetNewState(State newState)
        {
            currentState = newState;
            currentState.updateCount = 0;
            currentState.OnEnter();
        }

        public void TransitionToNextState()
        {
            if (_unit.unitData.listNextStates.Count > 0)
            {
                currentState.OnExit();

                SetNewState(_unit.unitData.listNextStates[_unit.unitData.listNextStates.Count - 1]);
                _unit.unitData.listNextStates.Clear();
            }
        }

        public State GetCurrentState()
        {
            return currentState;
        }
    }
}