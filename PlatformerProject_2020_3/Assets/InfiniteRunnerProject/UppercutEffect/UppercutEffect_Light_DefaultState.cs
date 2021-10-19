using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UppercutEffect_Light_DefaultState : UnitState
    {
        public UppercutEffect_Light_DefaultState()
        {
            _listMatchingSpriteTypes.Add(SpriteType.UPPERCUT_EFFECT_LIGHT);
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