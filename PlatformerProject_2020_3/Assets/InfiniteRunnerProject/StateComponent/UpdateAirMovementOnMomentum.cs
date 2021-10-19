using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UpdateAirMovementOnMomentum : StateComponent
    {
        public UpdateAirMovementOnMomentum(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            if (!UNIT_DATA.collisionStays.IsTouchingGround(CollisionType.BOTTOM) && !UNIT_DATA.collisionEnters.IsTouchingGround(CollisionType.BOTTOM))
            {
                UNIT_DATA.rigidBody2D.velocity = new Vector2(UNIT_DATA.airControl.HORIZONTAL_MOMENTUM, UNIT_DATA.rigidBody2D.velocity.y);
            }
        }
    }
}