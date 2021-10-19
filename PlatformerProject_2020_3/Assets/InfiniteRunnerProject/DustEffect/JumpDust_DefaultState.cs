using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class JumpDust_DefaultState : UnitState
    {
        public JumpDust_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.DUST_JUMP);
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