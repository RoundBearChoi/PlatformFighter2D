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

        public void UpdateState()
        {
            currentState.Update();
            currentState.updateCount++;
        }

        public void TransitionToNextState()
        {
            if (_unitData.listNextStates.Count > 0)
            {
                SetNewState(_unitData.listNextStates[_unitData.listNextStates.Count - 1]);
                _unitData.listNextStates.Clear();
            }
        }

        public void SetNewState(State newState)
        {
            currentState = newState;
            currentState.OnEnter();
        }
    }
}