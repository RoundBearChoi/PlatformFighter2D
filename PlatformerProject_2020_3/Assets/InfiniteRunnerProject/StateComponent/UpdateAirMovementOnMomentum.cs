using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UpdateAirMovementOnMomentum : StateComponent
    {
        public UpdateAirMovementOnMomentum(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (!_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM) && !_unit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM))
            {
                _unit.unitData.rigidBody2D.velocity = new Vector2(_unit.unitData.airControl.HORIZONTAL_MOMENTUM, _unit.unitData.rigidBody2D.velocity.y);
            }
        }
    }
}