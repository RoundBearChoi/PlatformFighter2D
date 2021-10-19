using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UpdateDirectionOnInput : StateComponent
    {
        public UpdateDirectionOnInput(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_LEFT, false))
            {
                UNIT_DATA.facingRight = false;
            }

            if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_RIGHT, false))
            {
                UNIT_DATA.facingRight = true;
            }
        }
    }
}