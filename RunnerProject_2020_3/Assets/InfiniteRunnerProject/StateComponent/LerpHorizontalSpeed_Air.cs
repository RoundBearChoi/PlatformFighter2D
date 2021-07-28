using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LerpHorizontalSpeed_Air : StateComponent
    {
        float _targetHorizontalForce = 0f;
        float _percentagePerUpdate = 0f;
        bool _zeroVerticalSpeed = false;

        public LerpHorizontalSpeed_Air(Unit unit, float targetHorizontalForce, float percentagePerUpdate, bool zeroVerticalSpeed)
        {
            _unit = unit;
            _targetHorizontalForce = targetHorizontalForce;
            _percentagePerUpdate = percentagePerUpdate;
            _zeroVerticalSpeed = zeroVerticalSpeed;
        }

        public override void OnFixedUpdate()
        {
            if (!_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                float dif = _unit.unitData.rigidBody2D.velocity.x - _targetHorizontalForce;

                if (Mathf.Abs(dif) > 0.001f)
                {
                    float x = Mathf.Lerp(_unit.unitData.rigidBody2D.velocity.x, _targetHorizontalForce, _percentagePerUpdate);
                    float y = 0f;

                    if (!_zeroVerticalSpeed)
                    {
                        y = _unit.unitData.rigidBody2D.velocity.y;
                    }

                    _unit.unitData.rigidBody2D.velocity = new Vector2(x, y);
                }
            }
        }
    }
}