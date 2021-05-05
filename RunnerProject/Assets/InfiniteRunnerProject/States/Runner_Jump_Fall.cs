using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Fall : State
    {
        public Runner_Jump_Fall(UnitData _unitData, UserInput _userInput)
        {
            unitData = _unitData;
            userInput = _userInput;
        }

        public override void OnEnter()
        {
            unitData.verticalVelocity = 0;
        }

        public override void Update()
        {
            if (unitData.unitTransform.position.y > 0f)
            {
                unitData.verticalVelocity -= 0.001f;
                unitData.unitTransform.position += new Vector3(unitData.horizontalVelocity, unitData.verticalVelocity, 0f);
            }
            else
            {
                nextState = new Runner_NormalRun(unitData, userInput);
            }
        }
    }
}