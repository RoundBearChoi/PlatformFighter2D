using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Idle : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public LittleRed_Idle(Unit unit)
        {
            ownerUnit = unit;
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, GameInitializer.current.fighterDataSO.IdleSlowDownLerpPercentage));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_LEFT))
            {
                ownerUnit.unitData.facingRight = false;
                ownerUnit.unitData.listNextStates.Add(new LittleRed_Run(ownerUnit));
            }

            if (ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_RIGHT))
            {
                ownerUnit.unitData.facingRight = true;
                ownerUnit.unitData.listNextStates.Add(new LittleRed_Run(ownerUnit));
            }
        }
    }
}