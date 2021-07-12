using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Golem_Idle : State
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Golem_Idle(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {

        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}