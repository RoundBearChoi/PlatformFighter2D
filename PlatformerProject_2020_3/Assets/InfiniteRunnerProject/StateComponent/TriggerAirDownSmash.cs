using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerAirDownSmash : StateComponent
    {
        public TriggerAirDownSmash(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_DOWN, false))
            {
                if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, false))
                {
                    UNIT.listNextStates.Add(new Runner_Smash_Air_Prep());
                }
            }
        }
    }
}