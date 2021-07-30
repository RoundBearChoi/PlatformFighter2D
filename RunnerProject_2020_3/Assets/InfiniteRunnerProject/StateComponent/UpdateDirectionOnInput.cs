using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UpdateDirectionOnInput : StateComponent
    {
        public UpdateDirectionOnInput(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_LEFT))
            {
                _unit.unitData.facingRight = false;
            }

            if (_unit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.MOVE_RIGHT))
            {
                _unit.unitData.facingRight = true;
            }
        }
    }
}