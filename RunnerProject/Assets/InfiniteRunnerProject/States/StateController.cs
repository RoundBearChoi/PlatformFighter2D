using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StateController
    {
        public StateController(State newState, GameElementData elementData)
        {
            SetNewState(newState, elementData);
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
                    SetNewState(currentState.nextState, elementData);
                    currentState.nextState = null;
                }
            }
        }

        public virtual void SetNewState(State newState, GameElementData elementData)
        {
            currentState = newState;
            currentState.OnEnter(elementData);
        }
    }
}