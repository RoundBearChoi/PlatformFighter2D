using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class JumpDust_DefaultState : UnitState
    {
        public static SpriteAnimationSpec animationSpec;

        public JumpDust_DefaultState(Unit unit)
        {
            ownerUnit = unit;
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                ownerUnit.destroy = true;
            }
        }
    }
}