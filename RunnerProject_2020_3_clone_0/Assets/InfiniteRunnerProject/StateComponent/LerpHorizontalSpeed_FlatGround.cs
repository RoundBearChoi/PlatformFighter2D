using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LerpHorizontalSpeed_FlatGround : StateComponent
    {
        float _targetHorizontalForce = 0f;
        float _percentagePerUpdate = 0f;

        public LerpHorizontalSpeed_FlatGround(Unit unit, float targetHorizontalForce, float percentagePerUpdate)
        {
            _unit = unit;
            _targetHorizontalForce = targetHorizontalForce;
            _percentagePerUpdate = percentagePerUpdate;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionStays.IsOnFlatGround())
            {
                float dif = _unit.unitData.rigidBody2D.velocity.x - _targetHorizontalForce;

                if (Mathf.Abs(dif) > 0.001f)
                {
                    float x = Mathf.Lerp(_unit.unitData.rigidBody2D.velocity.x, _targetHorizontalForce, _percentagePerUpdate);

                    _unit.unitData.rigidBody2D.velocity = new Vector2(x, _unit.unitData.rigidBody2D.velocity.y);
                }
            }
        }
    }
}