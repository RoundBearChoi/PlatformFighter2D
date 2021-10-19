using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SlowDownToZeroOnFlatGround : StateComponent
    {
        private float _percentagePerUpdate = 0f;

        public SlowDownToZeroOnFlatGround(UnitState unitState, float percentagePerUpdate)
        {
            _unitState = unitState;
            _percentagePerUpdate = percentagePerUpdate;
        }

        public override void OnFixedUpdate()
        {
            if (UNIT_DATA.collisionStays.IsOnFlatGround())
            {
                UNIT_DATA.rigidBody2D.velocity = Vector2.Lerp(UNIT_DATA.rigidBody2D.velocity, Vector2.zero, _percentagePerUpdate);
            }
        }
    }
}