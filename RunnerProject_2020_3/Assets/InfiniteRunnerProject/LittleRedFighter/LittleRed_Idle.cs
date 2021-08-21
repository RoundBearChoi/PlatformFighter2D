using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Idle : UnitState
    {
        public LittleRed_Idle(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, BaseInitializer.current.fighterDataSO.IdleSlowDownLerpPercentage));
            _listStateComponents.Add(new UpdateDirectionOnInput(ownerUnit));
            _listStateComponents.Add(new TriggerLittleRedAttackA(ownerUnit));
            _listStateComponents.Add(new TriggerFallState(ownerUnit));

            ownerUnit.unitData.airControl.SetMomentum(0f);
            ownerUnit.unitData.airControl.DashTriggered = false;

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_IDLE);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM) ||
                ownerUnit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM))
            {
                if (ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.JUMP))
                {
                    BaseMessage jumpDustMessage = new Message_ShowJumpDust(true, ownerUnit.transform.position);
                    jumpDustMessage.Register();

                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Up(ownerUnit, BaseInitializer.current.fighterDataSO.VerticalJumpForce, 0));
                }

                if (ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_LEFT))
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Run(ownerUnit));
                }

                if (ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_RIGHT))
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Run(ownerUnit));
                }
            }
        }
    }
}