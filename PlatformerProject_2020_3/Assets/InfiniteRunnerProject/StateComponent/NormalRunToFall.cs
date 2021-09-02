using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class NormalRunToFall : StateComponent
    {
        public NormalRunToFall(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            //in the air
            if (_unit.unitData.collisionStays.GetCount() == 0)
            {
                //falling
                if (_unit.unitData.rigidBody2D.velocity.y < 0f)
                {
                    _unit.unitData.listNextStates.Add(new Runner_Jump_Fall(_unit));
                }
            }
        }
    }
}