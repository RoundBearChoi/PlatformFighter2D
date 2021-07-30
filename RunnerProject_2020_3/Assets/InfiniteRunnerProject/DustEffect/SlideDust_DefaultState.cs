using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SlideDust_DefaultState : UnitState
    {
        public SlideDust_DefaultState(Unit unit)
        {
            ownerUnit = unit;

            _listMatchingSpriteTypes.Add(SpriteType.DUST_SLIDE);
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