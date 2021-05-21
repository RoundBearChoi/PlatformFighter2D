using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_NormalRun : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_SampleRunAnimation");

        public Runner_NormalRun(UnitData data, UserInput input)
        {
            _unitData = data;
            _userInput = input;
        }

        public override void OnEnter()
        {
            _unitData.horizontalVelocity = StaticRefs.gameData.RunnerHorizontalVelocity;
        }

        public override void Update()
        {
            if (JumpIsTriggered(_userInput))
            {
                nextState = new Runner_Jump_Up(_unitData, _userInput);
            }
            else
            {

                if (_unitData.unitTransform != null)
                {
                    _unitData.unitTransform.position += new Vector3(_unitData.horizontalVelocity, 0f, 0f);
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

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }
    }
}