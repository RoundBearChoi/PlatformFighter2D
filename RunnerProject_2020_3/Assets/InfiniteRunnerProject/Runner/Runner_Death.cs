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
            ownerUnit = unit;

            _listStateComponents.Add(new SlowDownToZeroOnFlatGround(ownerUnit, 0.05f));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}