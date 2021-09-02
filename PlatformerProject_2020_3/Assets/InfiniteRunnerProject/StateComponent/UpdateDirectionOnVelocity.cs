using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UpdateDirectionOnVelocity : StateComponent
    {
        public UpdateDirectionOnVelocity(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.rigidBody2D.velocity.x < 0f)
            {
                _unit.unitData.facingRight = false;
            }

            if (_unit.unitData.rigidBody2D.velocity.x > 0f)
            {
                _unit.unitData.facingRight = true;
            }
        }
    }
}