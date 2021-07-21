using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StepDust_DefaultState : UnitState
    {
        public static SpriteAnimationSpec animationSpec;

        public StepDust_DefaultState(Unit unit)
        {
            ownerUnit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (ownerUnit.unitData.spriteAnimations.currentAnimation.IsOnEnd())
            {
                ownerUnit.destroy = true;
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}