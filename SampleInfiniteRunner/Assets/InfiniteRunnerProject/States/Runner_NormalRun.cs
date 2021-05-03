using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_NormalRun : State
    {
        public Runner_NormalRun()
        {
            Debugger.Log("new state: Runner_NormalRun");
        }

        public override void OnEnter(GameElementData elementData)
        {
            elementData.horizontalVelocity = ObjStats.RunnerHorizontalVelocity;
        }

        public override void Update(UserInput userInput, GameElementData elementData)
        {
            if (JumpIsTriggered(userInput))
            {
                nextState = new Runner_Jump_Up();
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
                if (press.key == KeyboardKey.SPACE)
                {
                    return true;
                }
            }

            return false;
        }
    }
}