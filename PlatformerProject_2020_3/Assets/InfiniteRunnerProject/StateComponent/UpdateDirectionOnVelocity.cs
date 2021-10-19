using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UpdateDirectionOnVelocity : StateComponent
    {
        public UpdateDirectionOnVelocity(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            if (UNIT_DATA.rigidBody2D.velocity.x < 0f)
            {
                UNIT_DATA.facingRight = false;
            }

            if (UNIT_DATA.rigidBody2D.velocity.x > 0f)
            {
                UNIT_DATA.facingRight = true;
            }
        }
    }
}