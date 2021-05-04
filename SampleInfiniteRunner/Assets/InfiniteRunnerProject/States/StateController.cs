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

        public virtual void UpdateState()
        {
            if (currentState != null)
            {
                currentState.Update();
            }
        }

        public virtual void UpdateState(GameElementData elementData)
        {
            if (currentState != null)
            {
                currentState.Update(elementData);
            }
        }

        public virtual void UpdateState(UserInput userInput, GameElementData elementData)
        {
            if (currentState != null)
            {
                currentState.Update(userInput, elementData);
            }
        }

        public virtual void TransitionToNextState(GameElementData elementData)
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