using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DeathFX_Light_DefaultState : UnitState
    {
        public DeathFX_Light_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.DEATHFX_LIGHT);
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