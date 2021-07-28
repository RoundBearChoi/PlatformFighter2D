using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Smash_Air_Land : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Smash_Air_Land(Unit unit)
        {
            ownerUnit = unit;
            _listStateComponents.Add(new LerpHorizontalSpeed_Air(ownerUnit, 0f, 0.1f, true));
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, 0.1f));
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