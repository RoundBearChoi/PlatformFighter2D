using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SmashDust_DefaultState : UnitState
    {
        public SmashDust_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.DUST_SMASH);
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