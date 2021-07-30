using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Blood_5_DefaultState : UnitState
    {
        public static SpriteAnimationSpec animationSpec;

        public Blood_5_DefaultState(Unit unit)
        {
            ownerUnit = unit;

            _listMatchingSpriteTypes.Add(SpriteType.BLOOD_5);
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