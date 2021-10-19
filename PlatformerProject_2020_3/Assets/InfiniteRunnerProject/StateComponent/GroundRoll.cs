using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GroundRoll : StateComponent
    {
        float _speed = 0f;
        public GroundRoll(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            if (UNIT_DATA.collisionEnters.IsTouchingGround(CollisionType.BOTTOM) ||
                UNIT_DATA.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                OnGround();
            }
        }

        void OnGround()
        {
            UNIT.gameObject.layer = (int)LayerType.GHOSTING_UNIT;

            if (UNIT_DATA.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX <= 2)
            {
                _speed = BaseInitializer.CURRENT.fighterDataSO.DefaultRunSpeed * 1.5f;
            }
            else if (UNIT_DATA.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX <= 6)
            {
                _speed = BaseInitializer.CURRENT.fighterDataSO.DefaultRunSpeed * 0.8f;
            }
            else if (UNIT_DATA.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX <= 12)
            {
                _speed = Mathf.Lerp(UNIT_DATA.rigidBody2D.velocity.x, 0f, 0.07f);
            }
            else
            {
                UNIT_DATA.listNextStates.Add(new LittleRed_Idle());
            }

            UpdateSpeedDirection();
            UNIT_DATA.rigidBody2D.velocity = new Vector2(_speed, UNIT_DATA.rigidBody2D.velocity.y);
        }

        void UpdateSpeedDirection()
        {
            if (UNIT_DATA.facingRight)
            {
                if (_speed < 0)
                {
                    _speed *= -1f;
                }
            }
            else
            {
                if (_speed > 0)
                {
                    _speed *= -1f;
                }
            }
        }
    }
}