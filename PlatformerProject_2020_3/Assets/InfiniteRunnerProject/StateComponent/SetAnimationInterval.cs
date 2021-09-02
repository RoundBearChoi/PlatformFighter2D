using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SetAnimationInterval : StateComponent
    {
        private uint _targetInterval = 0;

        public SetAnimationInterval(Unit unit, uint targetInterval)
        {
            _unit = unit;
            _targetInterval = targetInterval;
        }

        public override void OnFixedUpdate()
        {
            SpriteAnimation ani = _unit.unitData.spriteAnimations.GetCurrentAnimation();
            ani.SetSpriteInterval(_targetInterval);
        }
    }
}