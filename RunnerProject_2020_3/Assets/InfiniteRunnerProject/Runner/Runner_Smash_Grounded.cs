using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Smash_Grounded : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Smash_Grounded(Unit unit)
        {
            ownerUnit = unit;
            _listStateComponents.Add(new LerpRunSpeedOnFlatGround(ownerUnit, 0f, 0.1f));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                ownerUnit.unitData.listNextStates.Add(new Runner_NormalRun(ownerUnit));
            }
        }
    }
}