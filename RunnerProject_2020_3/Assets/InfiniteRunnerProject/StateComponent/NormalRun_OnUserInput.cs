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
            if (Stage.currentStage.USER_INPUT.ContainsKeyPress(UserInput.keyboard.spaceKey) ||
                Stage.currentStage.USER_INPUT.ContainsKeyHold(UserInput.keyboard.spaceKey))
            {
                _unit.unitData.listNextStates.Add(new Runner_Jump_Up(_unit));
            }
            else if (Stage.currentStage.USER_INPUT.ContainsKeyPress(UserInput.keyboard.sKey) ||
                Stage.currentStage.USER_INPUT.ContainsKeyHold(UserInput.keyboard.sKey))
            {
                if (_unit.unitData.rigidBody2D.velocity.x > GameInitializer.current.gameDataSO.SlideSpeedThreshold)
                {   
                    _unit.unitData.listNextStates.Add(new Runner_Slide(_unit));
                }
                else
                {
                    _unit.unitData.listNextStates.Add(new Runner_Crouch(_unit));
                }
            }
            else if (Stage.currentStage.USER_INPUT.ContainsButtonPress(UserInput.mouse.leftButton))
            {
                BaseMessage showDashDust = new ShowDashDust_Message(true, _unit.transform.position);
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