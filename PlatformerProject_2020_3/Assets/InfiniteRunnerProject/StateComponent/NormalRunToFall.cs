using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class NormalRunToFall : StateComponent
    {
        public NormalRunToFall(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            //in the air
            if (UNIT_DATA.collisionStays.GetCount() == 0)
            {
                //falling
                if (UNIT_DATA.rigidBody2D.velocity.y < 0f)
                {
                    UNIT_DATA.listNextStates.Add(new Runner_Jump_Fall());
                }
            }
        }
    }
}