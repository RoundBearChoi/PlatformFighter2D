using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Idle : State
    {
        public Runner_Idle(GameElementData _elementData, UserInput _userInput)
        {
            elementData = _elementData;
            userInput = _userInput;
        }

        public override void Update()
        {
            nextState = new Runner_NormalRun(elementData, userInput);
        }
    }
}