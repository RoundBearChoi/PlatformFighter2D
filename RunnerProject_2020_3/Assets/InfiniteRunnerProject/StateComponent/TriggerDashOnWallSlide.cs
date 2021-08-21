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
                if (_unit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.SHIFT))
                {
                    if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.RIGHT))
                    {
                        if (_unit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_LEFT))
                        {

                            _unit.unitData.facingRight = false;
                            _unit.unitData.listNextStates.Add(new LittleRed_Dash(_unit));
                        }
                    }

                    if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.LEFT))
                    {
                        if (_unit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_RIGHT))
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