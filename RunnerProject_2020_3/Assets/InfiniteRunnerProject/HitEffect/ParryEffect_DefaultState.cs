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

            _listMatchingSpriteTypes.Add(SpriteType.HITEFFECT_PARRY);
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