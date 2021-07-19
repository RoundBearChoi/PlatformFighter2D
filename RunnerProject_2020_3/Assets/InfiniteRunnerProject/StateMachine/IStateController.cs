using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public interface IStateController<T>
    {
        public abstract void OnUpdate();
        public abstract void OnFixedUpdate();
        public abstract void OnLateUpdate();
        public abstract void SetNewState(T newUnitState);
        public abstract void TransitionToNextState();
        public abstract T GetCurrentState();
    }
}