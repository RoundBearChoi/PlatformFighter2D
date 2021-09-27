using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DeathFX_Dark_DefaultState : UnitState
    {
        public DeathFX_Dark_DefaultState(Unit unit)
        {
            ownerUnit = unit;

            _listMatchingSpriteTypes.Add(SpriteType.DEATHFX_DARK);
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