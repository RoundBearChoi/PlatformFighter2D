using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Jump_Up : UnitState
    {
        private float _jumpForce = 0f;

        public LittleRed_Jump_Up(Unit unit, float jumpForce, bool cancelJumpOnNonPress)
        {
            ownerUnit = unit;
            _jumpForce = jumpForce;

            if (cancelJumpOnNonPress)
            {
                _listStateComponents.Add(new CancelJumpForceOnNonPress(ownerUnit));
            }
            
            _listStateComponents.Add(new LerpHorizontalMomentumOnInput_Air(ownerUnit, BaseInitializer.current.fighterDataSO.MaxHorizontalAirMomentum));
            _listStateComponents.Add(new UpdateDirectionOnVelocity(ownerUnit));
            _listStateComponents.Add(new TriggerWallSlide(ownerUnit));
            _listStateComponents.Add(new TriggerLittleRedDash(ownerUnit));
            _listStateComponents.Add(new TriggerLittleRedAttackA(ownerUnit));

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
        }
    }
}