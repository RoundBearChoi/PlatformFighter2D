using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Idle : State
    {
        public Runner_Idle(UnitData _unitData, UserInput _userInput)
        {
            unitData = _unitData;
            userInput = _userInput;
        }

        public override void Update()
        {
            nextState = StateFactory.Create_Runner_NormalRun(unitData, userInput);
        }
    }
}