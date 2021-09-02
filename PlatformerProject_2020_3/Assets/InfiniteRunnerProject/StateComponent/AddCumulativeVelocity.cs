using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class AddCumulativeVelocity : StateComponent
    {
        float _addPercentage = 0f;

        public AddCumulativeVelocity(Unit unit, float addPercentage)
        {
            _unit = unit;
            _addPercentage = addPercentage;
        }

        public override void OnFixedUpdate()
        {
            if (!_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                float y = _unit.unitData.rigidBody2D.velocity.y * _addPercentage;

                _unit.unitData.rigidBody2D.velocity = new Vector2(_unit.unitData.rigidBody2D.velocity.x, y);
            }
        }
    }
}