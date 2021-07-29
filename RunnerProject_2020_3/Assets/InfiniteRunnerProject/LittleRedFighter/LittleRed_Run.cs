using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Run : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public LittleRed_Run(Unit unit)
        {
            ownerUnit = unit;

            float runspeed = GameInitializer.current.fighterDataSO.DefaultRunSpeed;

            if (!ownerUnit.unitData.facingRight)
            {
                runspeed *= -1f;
            }

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, runspeed, GameInitializer.current.fighterDataSO.RunSpeedLerpPercentage));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (!ownerUnit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_RIGHT))
            {
                ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
            }
        }
    }
}