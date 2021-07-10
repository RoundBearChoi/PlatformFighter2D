using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StepDust_DefaultState : State
    {
        private static SpriteAnimationSpec _animationSpec;

        public StepDust_DefaultState(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.spriteAnimations.currentAnimation.IsOnEnd())
            {
                _unit.destroy = true;
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return _animationSpec;
        }
    }
}