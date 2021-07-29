using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerAirDownSmash : StateComponent
    {
        public TriggerAirDownSmash(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_DOWN) || _unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_DOWN))
            {
                _unit.unitData.listNextStates.Add(new Runner_Smash_Air_Prep(_unit));
            }
        }
    }
}