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

            float runspeed = BaseInitializer.current.fighterDataSO.DefaultRunSpeed;

            if (!ownerUnit.unitData.facingRight)
            {
                runspeed *= -1f;
            }

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, runspeed, BaseInitializer.current.fighterDataSO.RunSpeedLerpPercentage));
            _listStateComponents.Add(new TriggerLittleRedAttackA(ownerUnit));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_RUN);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            //show step dust
            if (fixedUpdateCount != 0 && fixedUpdateCount % ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().animationSpec.spriteInterval == 0)
            {
                if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 1 ||
                    ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX == 6)
                {
                    BaseMessage showStepDust = new ShowStepDustMessage(false, ownerUnit.transform.position - new Vector3(ownerUnit.transform.right.x * 0.025f, 0f, 0f));
                    showStepDust.Register();
                }
            }

            if (ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM) ||
                ownerUnit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM))
            {
                if (ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.JUMP))
                {
                    BaseMessage jumpDustMessage = new ShowJumpDust_Message(true, ownerUnit.transform.position);
                    jumpDustMessage.Register();

                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Up(ownerUnit, BaseInitializer.current.fighterDataSO.JumpForce));
                }

                if (!ownerUnit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_RIGHT) && ownerUnit.unitData.facingRight)
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
                }

                if (!ownerUnit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_LEFT) && !ownerUnit.unitData.facingRight)
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
                }
            }
        }
    }
}