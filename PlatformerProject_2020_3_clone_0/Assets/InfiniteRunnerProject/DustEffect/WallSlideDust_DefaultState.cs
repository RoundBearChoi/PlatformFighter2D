using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class WallSlideDust_DefaultState : UnitState
    {
        public WallSlideDust_DefaultState(Unit unit)
        {
            ownerUnit = unit;

            _listMatchingSpriteTypes.Add(SpriteType.DUST_WALLSLIDE);
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