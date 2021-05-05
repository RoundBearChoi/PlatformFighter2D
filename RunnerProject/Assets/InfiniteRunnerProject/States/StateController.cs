using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StateController : StateControllerBase
    {
        public StateController(State newState)
        {
            SetNewState(newState);
        }

        public override void UpdateState()
        {
            if (currentState != null)
            {
                currentState.Update();
            }
        }

        public override void TransitionToNextState()
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

        public override void SetNewState(State newState)
        {
            currentState = newState;
            currentState.OnEnter();
        }
    }
}