using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class WallJumpDust_DefaultState : UnitState
    {
        public WallJumpDust_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.DUST_WALLJUMP);
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