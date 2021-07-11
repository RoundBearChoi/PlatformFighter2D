using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class NormalRun_OnUserInput : StateComponent
    {
        UserInput _userInput = null;

        public NormalRun_OnUserInput(Unit unit, UserInput userInput)
        {
            _unit = unit;
            _userInput = userInput;
        }

        public override void OnFixedUpdate()
        {
            if (_userInput.ContainsKeyPress(UserInput.keyboard.spaceKey))
            {
                _unit.unitData.listNextStates.Add(new Runner_Jump_Up(_unit, _userInput));
            }
            else if (_userInput.ContainsButtonPress(UserInput.mouse.leftButton))
            {
                _unit.unitData.listNextStates.Add(new Runner_AttackA(_unit, _userInput));
            }
        }
    }
}