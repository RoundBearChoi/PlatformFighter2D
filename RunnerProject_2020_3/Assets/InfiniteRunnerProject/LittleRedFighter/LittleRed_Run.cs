using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Run : UnitState
    {
        public LittleRed_Run(Unit unit)
        {
            ownerUnit = unit;

            float runspeed = GameInitializer.current.fighterDataSO.DefaultRunSpeed;

            if (!ownerUnit.unitData.facingRight)
            {
                runspeed *= -1f;
            }

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, runspeed, GameInitializer.current.fighterDataSO.RunSpeedLerpPercentage));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_RUN);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM) ||
                ownerUnit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM))
            {
                if (ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.JUMP))
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Up(ownerUnit));
                }

                if (!ownerUnit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_RIGHT) && ownerUnit.unitData.facingRight)
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
                }

                if (!ownerUnit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_LEFT) && !ownerUnit.unitData.facingRight)
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
                }

                if (ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A))
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Attack_A(ownerUnit));
                }
            }
                
        }
    }
}