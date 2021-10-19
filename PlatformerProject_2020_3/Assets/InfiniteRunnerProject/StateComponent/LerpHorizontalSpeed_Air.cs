using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LerpHorizontalSpeed_Air : StateComponent
    {
        float _targetForce = 0f;
        float _percentagePerUpdate = 0f;

        public LerpHorizontalSpeed_Air(UnitState unitState, float targetForce, float percentagePerUpdate)
        {
            _unitState = unitState;
            _targetForce = targetForce;
            _percentagePerUpdate = percentagePerUpdate;
        }

        public override void OnFixedUpdate()
        {
            if (!UNIT_DATA.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                float dif = UNIT_DATA.rigidBody2D.velocity.x - _targetForce;

                if (Mathf.Abs(dif) > 0.001f)
                {
                    float x = Mathf.Lerp(UNIT_DATA.rigidBody2D.velocity.x, _targetForce, _percentagePerUpdate);
                    UNIT_DATA.rigidBody2D.velocity = new Vector2(x, UNIT_DATA.rigidBody2D.velocity.y);
                }
            }
        }
    }
}