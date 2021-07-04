using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public interface IStateController
    {
        public abstract void OnFixedUpdate();
        public abstract void OnLateUpdate();
        public abstract void SetNewState(State newState);
        public abstract void TransitionToNextState();

        public abstract void SetSpriteAnimations(SpriteAnimations spriteAnimations);
        public abstract Hash128 GetAnimationHash();
    }
}