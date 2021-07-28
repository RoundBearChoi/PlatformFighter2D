using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerAirDownSmash : StateComponent
    {
        UserInput _userInput = null;

        public TriggerAirDownSmash(Unit unit)
        {
            _unit = unit;
            _userInput = GameInitializer.current.GetStage().USER_INPUT;
        }

        public override void OnFixedUpdate()
        {
            if (_userInput.ContainsButtonHold(UserInput.mouse.leftButton) && _userInput.ContainsKeyHold(UserInput.keyboard.sKey) ||
                _userInput.ContainsButtonPress(UserInput.mouse.leftButton) && _userInput.ContainsKeyPress(UserInput.keyboard.sKey))
            {
                Debugger.Log("smash!");
            }
        }
    }
}