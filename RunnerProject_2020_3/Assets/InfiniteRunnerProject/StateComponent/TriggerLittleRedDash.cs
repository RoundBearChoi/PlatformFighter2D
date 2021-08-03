using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerLittleRedDash : StateComponent
    {
        public TriggerLittleRedDash(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (!_unit.unitData.airControl.DashTriggered)
            {
                uint fixedUpdateCount = _unit.iStateController.GetCurrentState().fixedUpdateCount;

                if (_unit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.SHIFT) && fixedUpdateCount >= 1)
                {
                    if (_unit.unitData.facingRight)
                    {
                        if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT))
                        {
                            _unit.unitData.listNextStates.Add(new LittleRed_Dash(_unit));
                        }
                    }
                    else
                    {
                        if (_unit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_LEFT))
                        {
                            _unit.unitData.listNextStates.Add(new LittleRed_Dash(_unit));
                        }
                    }
                }
            }
        }
    }
}