using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DashDust_DefaultState : UnitState
    {
        public DashDust_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.DUST_DASH);
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