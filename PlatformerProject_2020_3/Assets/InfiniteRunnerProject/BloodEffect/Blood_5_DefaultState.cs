using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Blood_5_DefaultState : UnitState
    {
        public Blood_5_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.BLOOD_5);
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