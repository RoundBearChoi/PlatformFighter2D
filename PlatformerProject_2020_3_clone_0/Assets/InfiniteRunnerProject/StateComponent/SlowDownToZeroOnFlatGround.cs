using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SlowDownToZeroOnFlatGround : StateComponent
    {
        private float _percentagePerUpdate = 0f;

        public SlowDownToZeroOnFlatGround(Unit unit, float percentagePerUpdate)
        {
            _unit = unit;
            _percentagePerUpdate = percentagePerUpdate;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionStays.IsOnFlatGround())
            {
                _unit.unitData.rigidBody2D.velocity = Vector2.Lerp(_unit.unitData.rigidBody2D.velocity, Vector2.zero, _percentagePerUpdate);
            }
        }
    }
}