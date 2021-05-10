using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StateController : IStateController
    {
        public State currentState = null;

        public StateController(State newState)
        {
            SetNewState(newState);
        }

        public void UpdateState()
        {
            if (currentState != null)
            {
                currentState.Update();
                currentState.updateCount++;
            }
        }

        public void TransitionToNextState()
        {
            if (currentState != null)
            {
                if (currentState.nextState != null)
                {
                    SetNewState(currentState.nextState);
                    currentState.nextState = null;
                }
            }
        }

        public void SetNewState(State newState)
        {
            currentState = newState;
            currentState.OnEnter();
        }
    }
}