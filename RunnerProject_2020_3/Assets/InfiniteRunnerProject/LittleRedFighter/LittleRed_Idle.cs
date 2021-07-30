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
            _listStateComponents.Add(new UpdateDirectionOnInput(ownerUnit));

            ownerUnit.unitData.airControl.SetMomentum(0f);

            _listMatchingSpriteTypes.Add(SpriteType.LITTLERED_IDLE);
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.USER_INPUT != null)
            {
                if (ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM) ||
                    ownerUnit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM))
                {
                    if (ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.JUMP))
                    {
                        ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Up(ownerUnit));
                    }

                    if (ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_LEFT))
                    {
                        ownerUnit.unitData.listNextStates.Add(new LittleRed_Run(ownerUnit));
                    }

                    if (ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_RIGHT))
                    {
                        ownerUnit.unitData.listNextStates.Add(new LittleRed_Run(ownerUnit));
                    }

                    if (ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A))
                    {
                        ownerUnit.unitData.listNextStates.Add(new LittleRed_Attack_A(ownerUnit));
                    }
                }
            }
        }
    }
}