using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Golem_Death : State
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Golem_Death(Unit unit)
        {
            _unit = unit;
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}