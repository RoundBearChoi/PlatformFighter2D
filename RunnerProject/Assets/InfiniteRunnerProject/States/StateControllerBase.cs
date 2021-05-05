using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class StateControllerBase
    {
        public State currentState = null;

        public abstract void UpdateState();
        public abstract void UpdateState(GameElementData elementData);
        public abstract void UpdateState(UserInput userInput, GameElementData elementData);
        public abstract void TransitionToNextState(GameElementData elementData);
        public abstract void SetNewState(State newState, GameElementData elementData);
    }
}