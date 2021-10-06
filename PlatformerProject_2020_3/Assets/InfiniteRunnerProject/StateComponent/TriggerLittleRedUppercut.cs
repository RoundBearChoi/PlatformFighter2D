using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerLittleRedUppercut : StateComponent
    {
        public TriggerLittleRedUppercut(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_UP))
            {
                if (_unit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, false))
                {
                    Debugger.Log("uppercut!");
                    //_unit.unitData.listNextStates.Add(new LittleRed_Attack_A(_unit));
                }
            }
        }
    }
}