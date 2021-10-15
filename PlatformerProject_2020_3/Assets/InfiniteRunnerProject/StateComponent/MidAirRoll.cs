using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class MidAirRoll : StateComponent
    {
        float _minimumSpeed = 0f;

        public MidAirRoll(Unit unit)
        {
            _unit = unit;
            _minimumSpeed = 1f;
            UpdateSpeedDirection();
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM) ||
                _unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                return;
            }

            _unit.gameObject.layer = (int)LayerType.PHYSICAL_UNIT;

            if (_unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX <= 12)
            {
                float x = Mathf.Lerp(_unit.unitData.rigidBody2D.velocity.x, _minimumSpeed, 0.05f);
                _unit.unitData.rigidBody2D.velocity = new Vector2(x, _unit.unitData.rigidBody2D.velocity.y);
            }
            else
            {
                _unit.unitData.listNextStates.Add(new LittleRed_Jump_Fall(_unit));
            }
        }

        void UpdateSpeedDirection()
        {
            if (_unit.unitData.facingRight)
            {
                if (_minimumSpeed < 0)
                {
                    _minimumSpeed *= -1f;
                }

                _unit.unitData.airControl.SetMomentum(0.1f);
            }
            else
            {
                if (_minimumSpeed > 0)
                {
                    _minimumSpeed *= -1f;
                }

                _unit.unitData.airControl.SetMomentum(-0.1f);
            }
        }
    }
}