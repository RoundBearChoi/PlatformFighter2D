using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StateController : IStateController
    {
        public State currentState = null;

        private UnitData _unitData = null;

        public StateController(State newState, UnitData unitData)
        {
            _unitData = unitData;
            SetNewState(newState);
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
            if (_unitData.listNextStates.Count > 0)
            {
                SetNewState(_unitData.listNextStates[_unitData.listNextStates.Count - 1]);
                _unitData.listNextStates.Clear();
            }
        }

        public State GetCurrentState()
        {
            return currentState;
        }
    }
}