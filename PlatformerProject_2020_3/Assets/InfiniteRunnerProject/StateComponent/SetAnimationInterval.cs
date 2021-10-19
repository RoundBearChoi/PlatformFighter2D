using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SetAnimationInterval : StateComponent
    {
        private uint _targetInterval = 0;

        public SetAnimationInterval(UnitState unitState, uint targetInterval)
        {
            _unitState = unitState;
            _targetInterval = targetInterval;
        }

        public override void OnFixedUpdate()
        {
            SpriteAnimation ani = UNIT.spriteAnimations.GetCurrentAnimation();
            ani.SetSpriteInterval(_targetInterval);
        }
    }
}