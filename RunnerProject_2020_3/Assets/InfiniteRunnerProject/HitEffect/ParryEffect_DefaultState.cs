using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ParryEffect_DefaultState : UnitState
    {
        public static SpriteAnimationSpec animationSpec;

        public ParryEffect_DefaultState(Unit unit)
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