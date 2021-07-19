using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Death : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Death(Unit unit)
        {
            _unit = unit;

            _listStateComponents.Add(new SlowDownToZeroOnFlatGround(_unit, 0.05f));
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}