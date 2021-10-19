using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerJumpUp : StateComponent
    {
        public TriggerJumpUp(UnitState unitState)
        {
            _unitState = unitState;
        }

        public override void OnFixedUpdate()
        {
            if (UNIT.USER_INPUT.commands.ContainsPress(CommandType.JUMP, true))
            {
                if (!UNIT.isDummy)
                {
                    BaseMessage jumpDustMessage = new Message_ShowJumpDust(true, UNIT.transform.position);
                    jumpDustMessage.Register();
                }

                //multiply/divide runspeed on jump
                UNIT_DATA.rigidBody2D.velocity = new Vector2(UNIT_DATA.rigidBody2D.velocity.x * BaseInitializer.CURRENT.fighterDataSO.HorizontalMomentumMultiplierOnRunningJump, UNIT_DATA.rigidBody2D.velocity.y);
                UNIT_DATA.airControl.SetMomentum(UNIT_DATA.rigidBody2D.velocity.x);
                UNIT_DATA.listNextStates.Add(new LittleRed_Jump_Up(BaseInitializer.CURRENT.fighterDataSO.VerticalJumpForce, 0));
            }
        }
    }
}