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
            if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) == true &&
                _unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) == false)
            {
                Roll(false);
            }
            else if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) == false &&
                _unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) == true)
            {
                Roll(true);
            }
        }

        void Roll(bool faceRight)
        {
            if (_unit.USER_INPUT.commands.ContainsPress(CommandType.SHIFT, true))
            {
                _unit.unitData.facingRight = faceRight;
                _unit.unitData.listNextStates.Add(new LittleRed_Roll(_unit));
            }
        }
    }
}