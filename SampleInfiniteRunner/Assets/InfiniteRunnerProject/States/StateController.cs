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
            if (currentState != null)
            {
                currentState.Update();
            }
        }

        public void UpdateState(UserInput userInput, GameElement gameElement)
        {
            if (currentState != null)
            {
                currentState.Update(userInput, gameElement);
            }
        }

        public void TransitionToNextState()
        {
            if (currentState != null)
            {
                if (currentState.nextState != null)
                {
                    currentState = currentState.nextState;
                    currentState.nextState = null;
                }
            }
        }
    }
}