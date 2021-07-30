using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Attack_A : UnitState
    {
        public LittleRed_Attack_A(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, GameInitializer.current.fighterDataSO.AttackASlowDownPercentage));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_ATTACK_A);
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