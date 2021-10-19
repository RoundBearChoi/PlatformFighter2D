using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ParryEffect_DefaultState : UnitState
    {
        public ParryEffect_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.HITEFFECT_PARRY);
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