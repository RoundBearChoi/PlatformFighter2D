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
            if (_unit.USER_INPUT.commands.ContainsPress(CommandType.JUMP) || _unit.USER_INPUT.commands.ContainsHold(CommandType.JUMP))
            {
                _unit.unitData.listNextStates.Add(new Runner_Jump_Up(_unit));
            }
            else if (_unit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_DOWN) || _unit.USER_INPUT.commands.ContainsHold(CommandType.MOVE_DOWN))
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
            else if (_unit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A))
            {
                BaseMessage showDashDust = new ShowDashDust_Message(true, _unit.transform.position);
                showDashDust.Register();

                _unit.unitData.listNextStates.Add(new Runner_Attack_A_Dash(_unit));
            }
            else if (_unit.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_B))
            {
                _unit.unitData.listNextStates.Add(new Runner_Attack_B(_unit));
            }
        }
    }
}