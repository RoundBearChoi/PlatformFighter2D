using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : State
    {
        public Runner_Jump_Up(UnitData data, UserInput input)
        {
            _unitData = data;
            _userInput = input;
        }

        public override void OnEnter()
        {
            _unitData.verticalVelocity = StaticRefs.gameData.RunnerVerticalVelocity;
        }

        public override void Update()
        {
            if (_unitData.verticalVelocity >= 0f)
            {
                _unitData.unitTransform.position += new Vector3(_unitData.horizontalVelocity, _unitData.verticalVelocity, 0f);
                _unitData.verticalVelocity -= 0.001f;
            }
            else
            {
                _unitData.verticalVelocity = 0f;
                nextState = StateFactory.Create_Runner_Jump_Fall(_unitData, _userInput);
            }
        }
    }
}