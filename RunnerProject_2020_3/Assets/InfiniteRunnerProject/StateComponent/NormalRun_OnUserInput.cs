using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class NormalRun_OnUserInput : StateComponent
    {
        public NormalRun_OnUserInput(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (Stage.currentStage.USER_INPUT.ContainsKeyPress(UserInput.keyboard.spaceKey))
            {
                _unit.unitData.listNextStates.Add(new Runner_Jump_Up(_unit));
            }
            else if (Stage.currentStage.USER_INPUT.ContainsKeyPress(UserInput.keyboard.sKey))
            {
                _unit.unitData.listNextStates.Add(new Runner_Slide(_unit));
            }
            else if (Stage.currentStage.USER_INPUT.ContainsButtonPress(UserInput.mouse.leftButton))
            {
                BaseMessage showDashDust = new ShowDashDustMessage(true, _unit.transform.position);
                showDashDust.Register();

                _unit.unitData.listNextStates.Add(new Runner_AttackA_Dash(_unit));
            }
            else if (Stage.currentStage.USER_INPUT.ContainsButtonPress(UserInput.mouse.rightButton))
            {
                _unit.unitData.listNextStates.Add(new Runner_AttackB(_unit));
            }
        }
    }
}