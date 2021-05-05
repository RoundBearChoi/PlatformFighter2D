using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StateController : StateControllerBase
    {
        public StateController(State newState, GameElementData elementData)
        {
            SetNewState(newState, elementData);
        }

        public override void UpdateState()
        {
            if (currentState != null)
            {
                currentState.Update();
            }
        }

        public override void UpdateState(GameElementData elementData)
        {
            if (currentState != null)
            {
                currentState.Update(elementData);
            }
        }

        public override void UpdateState(UserInput userInput, GameElementData elementData)
        {
            if (currentState != null)
            {
                currentState.Update(userInput, elementData);
            }
        }

        public override void TransitionToNextState(GameElementData elementData)
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

        public override void SetNewState(State newState, GameElementData elementData)
        {
            currentState = newState;
            currentState.OnEnter(elementData);
        }
    }
}