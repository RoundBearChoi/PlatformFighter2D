using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class MidAirRoll : StateComponent
    {
        float _minimumSpeed = 0f;

        public MidAirRoll(UnitState unitState)
        {
            _unitState = unitState;
            _minimumSpeed = 1f;
            UpdateSpeedDirection();
        }

        public override void OnFixedUpdate()
        {
            if (UNIT_DATA.collisionStays.IsTouchingGround(CollisionType.BOTTOM) ||
                UNIT_DATA.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                return;
            }

            UNIT.gameObject.layer = (int)LayerType.PHYSICAL_UNIT;

            if (UNIT.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX <= 12)
            {
                float x = Mathf.Lerp(UNIT_DATA.rigidBody2D.velocity.x, _minimumSpeed, 0.05f);
                UNIT_DATA.rigidBody2D.velocity = new Vector2(x, UNIT_DATA.rigidBody2D.velocity.y);
            }
            else
            {
                UNIT.listNextStates.Add(new LittleRed_Jump_Fall());
            }
        }

        void UpdateSpeedDirection()
        {
            if (UNIT.facingRight)
            {
                if (_minimumSpeed < 0)
                {
                    _minimumSpeed *= -1f;
                }

                UNIT_DATA.airControl.SetMomentum(0.1f);
            }
            else
            {
                if (_minimumSpeed > 0)
                {
                    _minimumSpeed *= -1f;
                }

                UNIT_DATA.airControl.SetMomentum(-0.1f);
            }
        }
    }
}