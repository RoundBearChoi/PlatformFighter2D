using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UppercutEffect_Light_DefaultState : UnitState
    {
        public UppercutEffect_Light_DefaultState(Unit unit)
        {
            ownerUnit = unit;

            _listMatchingSpriteTypes.Add(SpriteType.UPPERCUT_EFFECT_LIGHT);
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