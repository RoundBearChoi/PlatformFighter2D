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

        public override void Update(UserInput userInput, GameElement gameElement)
        {
            if (JumpIsTriggered(userInput))
            {
                nextState = new Runner_Jump_Up();
            }
            else
            {
                gameElement.transform.position += new Vector3(0.01f, 0f, 0f);
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