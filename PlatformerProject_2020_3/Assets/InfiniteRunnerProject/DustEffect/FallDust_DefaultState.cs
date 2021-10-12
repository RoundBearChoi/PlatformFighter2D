using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FallDust_DefaultState : UnitState
    {
        public FallDust_DefaultState(Unit unit)
        {
            ownerUnit = unit;

            _listMatchingSpriteTypes.Add(SpriteType.DUST_FALL);
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