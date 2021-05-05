using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_NormalRun : State
    {
        public Runner_NormalRun(GameElementData _elementData, UserInput _userInput)
        {
            elementData = _elementData;
            userInput = _userInput;
        }

        public override void OnEnter()
        {
            elementData.horizontalVelocity = StaticRefs.gameData.RunnerHorizontalVelocity;
        }

        public override void Update()
        {
            if (JumpIsTriggered(userInput))
            {
                nextState = new Runner_Jump_Up(elementData, userInput);
            }
            else
            {

                if (elementData.elementTransform != null)
                {
                    elementData.elementTransform.position += new Vector3(elementData.horizontalVelocity, 0f, 0f);
                }
            }
        }

        bool JumpIsTriggered(UserInput userInput)
        {
            foreach (KeyPress press in userInput.listPresses)
            {
                if (press.keyCode == KeyCode.Space)
                {
                    return true;
                }
            }

            return false;
        }
    }
}