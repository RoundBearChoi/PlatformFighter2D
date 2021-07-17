using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class NormalRun_OnUserInput : StateComponent
    {
        public NormalRun_OnUserInput(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (Stage.currentStage.USER_INPUT.ContainsKeyPress(UserInput.keyboard.spaceKey))
            {
                _unit.unitData.listNextStates.Add(new Runner_Jump_Up(_unit));
            }
            else if (Stage.currentStage.USER_INPUT.ContainsButtonPress(UserInput.mouse.leftButton))
            {
                _unit.unitData.listNextStates.Add(new Runner_AttackA(_unit));
            }
        }
    }
}