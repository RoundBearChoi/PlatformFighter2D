using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SetDefaultAnimationInterval : StateComponent
    {
        public SetDefaultAnimationInterval(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            SpriteAnimation ani = UNIT.spriteAnimations.GetCurrentAnimation();
            ani.SetSpriteInterval(ani.ANIMATION_SPEC.spriteInterval);
        }
    }
}