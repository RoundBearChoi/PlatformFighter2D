using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public interface IStateController
    {
        public abstract void UpdateState();
        public abstract void TransitionToNextState();
        public abstract void SetNewState(State newState);
    }
}