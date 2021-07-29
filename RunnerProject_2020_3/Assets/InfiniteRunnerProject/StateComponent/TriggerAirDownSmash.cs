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
            if (_userInput.userCommands.ContainsHold(CommandType.MOVE_DOWN) || _userInput.userCommands.ContainsPress(CommandType.MOVE_DOWN))
            {
                _unit.unitData.listNextStates.Add(new Runner_Smash_Air_Prep(_unit));
            }
        }
    }
}