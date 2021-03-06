using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FallDust_DefaultState : UnitState
    {
        public FallDust_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.DUST_FALL);
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