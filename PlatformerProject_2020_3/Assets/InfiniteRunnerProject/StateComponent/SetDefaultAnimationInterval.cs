using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SetDefaultAnimationInterval : StateComponent
    {
        public SetDefaultAnimationInterval(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            SpriteAnimation ani = _unit.unitData.spriteAnimations.GetCurrentAnimation();
            ani.SetSpriteInterval(ani.ANIMATION_SPEC.spriteInterval);
        }
    }
}