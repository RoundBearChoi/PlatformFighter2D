using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SmashDust_DefaultState : UnitState
    {
        public static SpriteAnimationSpec animationSpec;

        public SmashDust_DefaultState(Unit unit)
        {
            ownerUnit = unit;

            _listMatchingSpriteTypes.Add(SpriteType.DUST_SMASH);
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