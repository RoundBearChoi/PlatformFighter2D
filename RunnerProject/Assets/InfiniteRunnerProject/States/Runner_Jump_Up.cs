using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : State
    {
        public Runner_Jump_Up(UnitData _unitData, UserInput _userInput)
        {
            unitData = _unitData;
            userInput = _userInput;
        }

        public override void OnEnter()
        {
            unitData.verticalVelocity = StaticRefs.gameData.RunnerVerticalVelocity;
        }

        public override void Update()
        {
            if (unitData.verticalVelocity >= 0f)
            {
                unitData.unitTransform.position += new Vector3(unitData.horizontalVelocity, unitData.verticalVelocity, 0f);
                unitData.verticalVelocity -= 0.001f;
            }
            else
            {
                unitData.verticalVelocity = 0f;
                nextState = new Runner_Jump_Fall(unitData, userInput);
            }
        }
    }
}