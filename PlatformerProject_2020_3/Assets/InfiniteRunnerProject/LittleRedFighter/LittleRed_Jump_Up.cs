using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Jump_Up : UnitState
    {
        private float _jumpForce = 0f;

        public LittleRed_Jump_Up(float jumpForce, uint defaultJumpFrames)
        {
            disallowTransitionQueue = true;

            _jumpForce = jumpForce;

            _listStateComponents.Add(new CancelJumpForceOnNonPress(this, defaultJumpFrames));
            
            _listStateComponents.Add(new LerpHorizontalMomentumOnInput_Air(this, BaseInitializer.CURRENT.fighterDataSO.MaxHorizontalAirMomentum));
            _listStateComponents.Add(new UpdateAirMovementOnMomentum(this));

            _listStateComponents.Add(new UpdateDirectionOnVelocity(this));

            _listStateComponents.Add(new TriggerLittleRedUppercut(this, 0));
            _listStateComponents.Add(new TriggerWallSlide(this));
            _listStateComponents.Add(new TriggerAirDash(this, 0));
            _listStateComponents.Add(new TriggerLittleRedAttackA(this, 0));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_JUMP_UP);
        }

        public override void OnEnter()
        {
            _ownerUnit.unitData.rigidBody2D.velocity = new Vector2(_ownerUnit.unitData.rigidBody2D.velocity.x * BaseInitializer.CURRENT.fighterDataSO.HorizontalJumpVelocityMultiplier, _jumpForce);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_ownerUnit.unitData.rigidBody2D.velocity.y <= 0f && fixedUpdateCount >= 2)
            {
                _ownerUnit.listNextStates.Add(new LittleRed_Jump_Fall());
            }
        }
    }
}