using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_NormalRun : State
    {
        public Runner_NormalRun(UnitData _unitData, UserInput _userInput)
        {
            unitData = _unitData;
            userInput = _userInput;
        }

        public override void OnEnter()
        {
            unitData.horizontalVelocity = StaticRefs.gameData.RunnerHorizontalVelocity;
        }

        public override void Update()
        {
            if (JumpIsTriggered(userInput))
            {
                nextState = new Runner_Jump_Up(unitData, userInput);
            }
            else
            {

                if (unitData.unitTransform != null)
                {
                    unitData.unitTransform.position += new Vector3(unitData.horizontalVelocity, 0f, 0f);
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