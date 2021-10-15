using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerGroundRoll : StateComponent
    {
        public TriggerGroundRoll(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {

            if (_unit.USER_INPUT.commands.ContainsPress(CommandType.SHIFT, false))
            {
                if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) == true &&
                    _unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) == false)
                {
                    _unit.unitData.facingRight = false;
                    _unit.unitData.listNextStates.Add(new LittleRed_GroundRoll(_unit));
                }
                else if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) == false &&
                    _unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) == true)
                {
                    _unit.unitData.facingRight = true;
                    _unit.unitData.listNextStates.Add(new LittleRed_GroundRoll(_unit));
                }
            }
        }
    }
}