using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GroundRoll : StateComponent
    {
        float _speed = 0f;
        public GroundRoll(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM) ||
                _unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                OnGround();
            }
        }

        void OnGround()
        {
            _unit.gameObject.layer = (int)LayerType.GHOSTING_UNIT;

            if (_unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX <= 2)
            {
                _speed = BaseInitializer.CURRENT.fighterDataSO.DefaultRunSpeed * 1.5f;
            }
            else if (_unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX <= 6)
            {
                _speed = BaseInitializer.CURRENT.fighterDataSO.DefaultRunSpeed * 0.8f;
            }
            else if (_unit.unitData.spriteAnimations.GetCurrentAnimation().SPRITE_INDEX <= 12)
            {
                _speed = Mathf.Lerp(_unit.unitData.rigidBody2D.velocity.x, 0f, 0.07f);
            }
            else
            {
                _unit.unitData.listNextStates.Add(new LittleRed_Idle(_unit));
            }

            UpdateSpeedDirection();
            _unit.unitData.rigidBody2D.velocity = new Vector2(_speed, _unit.unitData.rigidBody2D.velocity.y);
        }

        void UpdateSpeedDirection()
        {
            if (_unit.unitData.facingRight)
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