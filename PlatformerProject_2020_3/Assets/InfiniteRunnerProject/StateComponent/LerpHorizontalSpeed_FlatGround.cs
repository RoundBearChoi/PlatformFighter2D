using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LerpHorizontalSpeed_FlatGround : StateComponent
    {
        float _targetHorizontalForce = 0f;
        float _percentagePerUpdate = 0f;

        public LerpHorizontalSpeed_FlatGround(UnitState unitState, float targetHorizontalForce, float percentagePerUpdate)
        {
            _unitState = unitState;
            _targetHorizontalForce = targetHorizontalForce;
            _percentagePerUpdate = percentagePerUpdate;
        }

        public override void OnFixedUpdate()
        {
            if (UNIT_DATA.collisionStays.IsOnFlatGround())
            {
                float dif = UNIT_DATA.rigidBody2D.velocity.x - _targetHorizontalForce;

                if (Mathf.Abs(dif) > 0.001f)
                {
                    float x = Mathf.Lerp(UNIT_DATA.rigidBody2D.velocity.x, _targetHorizontalForce, _percentagePerUpdate);
                    UNIT_DATA.rigidBody2D.velocity = new Vector2(x, UNIT_DATA.rigidBody2D.velocity.y);
                }
            }
        }
    }
}