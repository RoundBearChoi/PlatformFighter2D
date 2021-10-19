using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerIdleOnGround : StateComponent
    {
        public TriggerIdleOnGround(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            if (UNIT_DATA.collisionStays.IsTouchingGround(CollisionType.BOTTOM) ||
                UNIT_DATA.collisionEnters.IsTouchingGround(CollisionType.BOTTOM))
            {
                if (!UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) && UNIT.facingRight)
                {
                    UNIT.listNextStates.Add(new LittleRed_Idle());
                }

                if (!UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) && !UNIT.facingRight)
                {
                    UNIT.listNextStates.Add(new LittleRed_Idle());
                }
            }
        }
    }
}