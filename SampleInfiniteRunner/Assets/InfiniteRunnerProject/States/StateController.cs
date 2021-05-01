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

        public void UpdateState(UserInput userInput, GameElementData elementData)
        {
            if (currentState != null)
            {
                currentState.Update(userInput, elementData);
            }
        }

        public void TransitionToNextState(GameElementData elementData)
        {
            if (currentState != null)
            {
                if (currentState.nextState != null)
                {
                    currentState.nextState.OnEnter(elementData);
                    currentState = currentState.nextState;
                    currentState.nextState = null;
                }
            }
        }
    }
}