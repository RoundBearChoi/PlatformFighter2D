using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : State
    {
        public Runner_Jump_Up()
        {
            Debugger.Log("new state: Runner_Jump_Up");
        }

        public override void OnEnter(GameElementData elementData)
        {
            elementData.verticalVelocity = ObjStats.RunnerVerticalVelocity;
        }

        public override void Update(UserInput userInput, GameElementData elementData)
        {
            if (elementData.verticalVelocity >= 0f)
            {
                elementData.elementTransform.position += new Vector3(elementData.horizontalVelocity, elementData.verticalVelocity, 0f);
                elementData.verticalVelocity -= 0.001f;
            }
            else
            {
                elementData.verticalVelocity = 0f;
                nextState = new Runner_Jump_Fall();
            }
        }
    }
}