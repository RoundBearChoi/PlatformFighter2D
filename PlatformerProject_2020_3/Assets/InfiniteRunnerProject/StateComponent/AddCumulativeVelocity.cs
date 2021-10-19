using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class AddCumulativeVelocity : StateComponent
    {
        float _addPercentage = 0f;

        public AddCumulativeVelocity(UnitState unitState, float addPercentage)
        {
            _unitState = unitState;
            _addPercentage = addPercentage;
        }

        public override void OnFixedUpdate()
        {
            if (!UNIT_DATA.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                float y = UNIT_DATA.rigidBody2D.velocity.y * _addPercentage;

                UNIT_DATA.rigidBody2D.velocity = new Vector2(UNIT_DATA.rigidBody2D.velocity.x, y);
            }
        }
    }
}