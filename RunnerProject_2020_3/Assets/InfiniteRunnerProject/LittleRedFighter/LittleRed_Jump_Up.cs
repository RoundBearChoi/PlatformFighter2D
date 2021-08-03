using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Jump_Up : UnitState
    {
        private float _jumpForce = 0f;

        public LittleRed_Jump_Up(Unit unit, float jumpForce)
        {
            ownerUnit = unit;
            _jumpForce = jumpForce;

            _listStateComponents.Add(new CancelJumpForce(ownerUnit));
            _listStateComponents.Add(new LerpHorizontalMomentumOnInput_Air(ownerUnit, BaseInitializer.current.fighterDataSO.MaxHorizontalAirMomentum));
            _listStateComponents.Add(new UpdateDirectionOnVelocity(ownerUnit));
            _listStateComponents.Add(new TriggerWallSlide(ownerUnit));
            _listStateComponents.Add(new TriggerLittleRedAttackA(ownerUnit));
            _listStateComponents.Add(new TriggerLittleRedDash(ownerUnit));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_JUMP_UP);
        }

        public override void OnEnter()
        {
            //not changing velocity atm
            float x = ownerUnit.unitData.rigidBody2D.velocity.x * 1f;
            ownerUnit.unitData.rigidBody2D.velocity = new Vector2(x, _jumpForce);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.rigidBody2D.velocity.y <= 0f && fixedUpdateCount >= 2)
            {
                ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Fall(ownerUnit));
            }

            //if (ownerUnit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.SHIFT) && fixedUpdateCount >= 2)
            //{
            //    if (ownerUnit.unitData.facingRight)
            //    {
            //        if (ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT))
            //        {
            //            ownerUnit.unitData.listNextStates.Add(new LittleRed_Dash(ownerUnit));
            //        }
            //    }
            //    else
            //    {
            //        if (ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT))
            //        {
            //            ownerUnit.unitData.listNextStates.Add(new LittleRed_Dash(ownerUnit));
            //        }
            //    }
            //}
        }
    }
}