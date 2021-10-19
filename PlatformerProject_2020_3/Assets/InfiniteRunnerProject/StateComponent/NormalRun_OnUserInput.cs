using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class NormalRun_OnUserInput : StateComponent
    {
        public NormalRun_OnUserInput(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.JUMP, false))
            {
                UNIT.listNextStates.Add(new Runner_Jump_Up());
            }
            else if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.MOVE_DOWN, false))
            {
                if (UNIT_DATA.rigidBody2D.velocity.x > BaseInitializer.CURRENT.runnerDataSO.SlideSpeedThreshold)
                {
                    UNIT.listNextStates.Add(new Runner_Slide());
                }
                else
                {
                    UNIT.listNextStates.Add(new Runner_Crouch());
                }
            }
            else if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_A, false))
            {
                BaseMessage showDashDust = new Message_ShowDashDust(true, UNIT.transform.position);
                showDashDust.Register();

                UNIT.listNextStates.Add(new Runner_Attack_A_Dash());
            }
            else if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.ATTACK_B, false))
            {
                UNIT.listNextStates.Add(new Runner_Attack_B());
            }
        }
    }
}