using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Idle : State
    {
        public Runner_Idle(UnitData data, UserInput input)
        {
            _unitData = data;
            _userInput = input;
        }

        public override void Update()
        {
            //nextState = new Runner_NormalRun(_unitData, _userInput);
        }
    }
}