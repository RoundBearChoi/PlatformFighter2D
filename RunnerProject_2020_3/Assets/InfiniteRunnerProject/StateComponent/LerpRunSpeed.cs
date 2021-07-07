using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LerpRunSpeed : StateComponent
    {
        float _targetHorizontalForce = 0f;
        float _lerpRate = 0f;

        public LerpRunSpeed(Unit unit, float targetHorizontalForce, float lerpRate)
        {
            _unit = unit;
            _targetHorizontalForce = targetHorizontalForce;
            _lerpRate = lerpRate;
        }

        public override void Update()
        {
            float dif = _unit.unitData.rigidBody2D.velocity.x - _targetHorizontalForce;

            if (Mathf.Abs(dif) > 0.001f)
            {
                float x = Mathf.Lerp(_unit.unitData.rigidBody2D.velocity.x, _targetHorizontalForce, _lerpRate);

                _unit.unitData.rigidBody2D.velocity = new Vector2(x, _unit.unitData.rigidBody2D.velocity.y);
            }
        }
    }
}