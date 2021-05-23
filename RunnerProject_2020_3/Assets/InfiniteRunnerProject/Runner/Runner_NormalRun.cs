using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

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
            if (_userInput.ContainsKeyPress(UserInput.keyboard.spaceKey) /*JumpIsTriggered(_userInput)*/)
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

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }
    }
}