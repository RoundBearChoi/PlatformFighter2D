using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Smash_Air_Fall : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Smash_Air_Fall(Unit unit)
        {
            ownerUnit = unit;
            _listStateComponents.Add(new LerpHorizontalSpeed_Air(ownerUnit, 0f, 0.1f, true));
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
                if (ownerUnit.unitData.rigidBody2D.velocity.x <= 0.01f)
                {
                    ownerUnit.unitData.listNextStates.Add(new Runner_Smash_Air_Land(ownerUnit));
                }
            }
        }
    }
}