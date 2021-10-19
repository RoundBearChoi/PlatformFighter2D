using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerGroundRoll : StateComponent
    {
        public TriggerGroundRoll(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) == true &&
                UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) == false)
            {
                Roll(false);
            }
            else if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false) == false &&
                UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false) == true)
            {
                Roll(true);
            }
        }

        void Roll(bool faceRight)
        {
            if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.SHIFT, true))
            {
                UNIT.facingRight = faceRight;
                UNIT.listNextStates.Add(new LittleRed_Roll());
            }
        }
    }
}