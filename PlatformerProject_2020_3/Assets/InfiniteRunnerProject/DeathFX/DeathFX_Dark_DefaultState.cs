using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DeathFX_Dark_DefaultState : UnitState
    {
        public DeathFX_Dark_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.DEATHFX_DARK);
        }

        public override void OnFixedUpdate()
        {
            if (_ownerUnit.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                _ownerUnit.destroy = true;
            }
        }
    }
}