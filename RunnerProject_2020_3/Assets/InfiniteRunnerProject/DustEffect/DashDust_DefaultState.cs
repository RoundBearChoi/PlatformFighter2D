using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DashDust_DefaultState : State
    {
        public static SpriteAnimationSpec animationSpec;

        public DashDust_DefaultState(Unit unit)
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
            return animationSpec;
        }
    }
}