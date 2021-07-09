using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FrontEnemy_Idle : State
    {
        public FrontEnemy_Idle(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {

        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return null;
        }
    }
}