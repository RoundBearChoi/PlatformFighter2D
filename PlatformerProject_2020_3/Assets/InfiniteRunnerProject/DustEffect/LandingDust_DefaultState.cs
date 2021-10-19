using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LandingDust_DefaultState : UnitState
    {
        public LandingDust_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.DUST_LAND);
        }

        public override void OnFixedUpdate()
        {
            if (ownerUnit.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                ownerUnit.destroy = true;
            }
        }
    }
}