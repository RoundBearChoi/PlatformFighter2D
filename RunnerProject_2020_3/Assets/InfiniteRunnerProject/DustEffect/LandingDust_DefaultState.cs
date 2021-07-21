using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LandingDust_DefaultState : UnitState
    {
        public static SpriteAnimationSpec animationSpec;

        public LandingDust_DefaultState(Unit unit)
        {
            ownerUnit = unit;
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            if (ownerUnit.unitData.spriteAnimations.currentAnimation.IsOnEnd())
            {
                ownerUnit.destroy = true;
            }
        }
    }
}