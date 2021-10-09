using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerDashOnWallSlide : StateComponent
    {
        public TriggerDashOnWallSlide(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (!_unit.unitData.airControl.DashTriggered)
            {
                if (_unit.USER_INPUT.commands.ContainsPress(CommandType.SHIFT, false))
                {
                    if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.RIGHT))
                    {
                        if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false))
                        {

                            _unit.unitData.facingRight = false;
                            _unit.unitData.listNextStates.Add(new LittleRed_Dash(_unit));
                        }
                    }

                    if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.LEFT))
                    {
                        if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false))
                        {
                            _unit.unitData.facingRight = true;
                            _unit.unitData.listNextStates.Add(new LittleRed_Dash(_unit));
                        }
                    }
                }
            }
        }
    }
}