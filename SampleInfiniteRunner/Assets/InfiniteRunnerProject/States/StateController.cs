using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StateController
    {
        public StateController(State initialState)
        {
            currentState = initialState;
        }

        public State currentState = null;

        public void UpdateState()
        {
            TransitionToNextState();

            if (currentState != null)
            {
                currentState.Update();
            }
        }

        public void TransitionToNextState()
        {

        }
    }
}