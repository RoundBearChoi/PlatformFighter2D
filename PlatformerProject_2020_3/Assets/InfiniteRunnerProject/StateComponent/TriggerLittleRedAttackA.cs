using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerLittleRedAttackA : StateComponent
    {
        public TriggerLittleRedAttackA(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, false))
            {
                _unit.unitData.listNextStates.Add(new LittleRed_Attack_A(_unit));
            }
        }
    }
}