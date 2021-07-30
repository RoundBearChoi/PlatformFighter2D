using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Attack_A : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public LittleRed_Attack_A(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, GameInitializer.current.fighterDataSO.AttackASlowDownPercentage));
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
                ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
            }
        }
    }
}