using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : State
    {
        public Runner_Jump_Up(GameElementData _elementData, UserInput _userInput)
        {
            elementData = _elementData;
            userInput = _userInput;
        }

        public override void OnEnter()
        {
            elementData.verticalVelocity = StaticRefs.gameData.RunnerVerticalVelocity;
        }

        public override void Update()
        {
            if (elementData.verticalVelocity >= 0f)
            {
                elementData.elementTransform.position += new Vector3(elementData.horizontalVelocity, elementData.verticalVelocity, 0f);
                elementData.verticalVelocity -= 0.001f;
            }
            else
            {
                elementData.verticalVelocity = 0f;
                nextState = new Runner_Jump_Fall(elementData, userInput);
            }
        }
    }
}