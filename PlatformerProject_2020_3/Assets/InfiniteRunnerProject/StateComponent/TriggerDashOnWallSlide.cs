using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerDashOnWallSlide : StateComponent
    {
        public TriggerDashOnWallSlide(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            if (!UNIT_DATA.airControl.DashTriggered)
            {
                if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.SHIFT, false))
                {
                    if (UNIT_DATA.collisionStays.IsTouchingGround(CollisionType.RIGHT))
                    {
                        if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false))
                        {

                            UNIT.facingRight = false;
                            UNIT.listNextStates.Add(new LittleRed_Dash());
                        }
                    }

                    if (UNIT_DATA.collisionStays.IsTouchingGround(CollisionType.LEFT))
                    {
                        if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false))
                        {
                            UNIT.facingRight = true;
                            UNIT.listNextStates.Add(new LittleRed_Dash());
                        }
                    }
                }
            }
        }
    }
}