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
            if (_unit.USER_INPUT.commands.ContainsPress(CommandType.JUMP, false) || _unit.USER_INPUT.commands.ContainsHold(CommandType.JUMP))
            {
                _unit.unitData.listNextStates.Add(new Runner_Jump_Up(_unit));
            }
            else if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_DOWN, false) || _unit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_DOWN))
            {
                if (_unit.unitData.rigidBody2D.velocity.x > BaseInitializer.current.runnerDataSO.SlideSpeedThreshold)
                {   
                    _unit.unitData.listNextStates.Add(new Runner_Slide(_unit));
                }
                else
                {
                    _unit.unitData.listNextStates.Add(new Runner_Crouch(_unit));
                }
            }
            else if (_unit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, false))
            {
                BaseMessage showDashDust = new Message_ShowDashDust(true, _unit.transform.position);
                showDashDust.Register();

                _unit.unitData.listNextStates.Add(new Runner_Attack_A_Dash(_unit));
            }
            else if (_unit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_B, false))
            {
                _unit.unitData.listNextStates.Add(new Runner_Attack_B(_unit));
            }
        }
    }
}