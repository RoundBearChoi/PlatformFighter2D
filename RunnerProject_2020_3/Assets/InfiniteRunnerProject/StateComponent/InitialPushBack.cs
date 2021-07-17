using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class InitialPushBack : StateComponent
    {
        private bool _initialPushBack = false;
        private Vector2 _force = Vector2.zero;

        public InitialPushBack(Unit unit, Vector2 force)
        {
            _unit = unit;
            _force = force;
        }

        public override void OnFixedUpdate()
        {
            if (!_initialPushBack)
            {
                _initialPushBack = true;

                Vector3 push = Vector3.zero;

                if (!_unit.unitData.facingRight)
                {
                    push = (_unit.transform.right * _force.x * -1f) + (Vector3.up * _force.y);
                }
                else
                {
                    push = (_unit.transform.right * _force.x) + (Vector3.up * _force.y);
                }

                _unit.unitData.rigidBody2D.velocity = push;
            }
        }
    }
}