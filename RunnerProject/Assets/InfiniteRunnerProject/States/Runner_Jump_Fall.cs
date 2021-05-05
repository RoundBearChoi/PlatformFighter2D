using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Fall : State
    {
        public Runner_Jump_Fall(GameElementData _elementData, UserInput _userInput)
        {
            elementData = _elementData;
            userInput = _userInput;
        }

        public override void OnEnter()
        {
            elementData.verticalVelocity = 0;
        }

        public override void Update()
        {
            if (elementData.elementTransform.position.y > 0f)
            {
                elementData.verticalVelocity -= 0.001f;
                elementData.elementTransform.position += new Vector3(elementData.horizontalVelocity, elementData.verticalVelocity, 0f);
            }
            else
            {
                nextState = new Runner_NormalRun(elementData, userInput);
            }
        }
    }
}