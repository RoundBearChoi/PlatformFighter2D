using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SlideDust_DefaultState : UnitState
    {
        public SlideDust_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.DUST_SLIDE);
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