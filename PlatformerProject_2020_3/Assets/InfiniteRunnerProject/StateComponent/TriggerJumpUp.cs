using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TriggerJumpUp : StateComponent
    {
        public TriggerJumpUp(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM) ||
                _unit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM))
            {
                if (_unit.USER_INPUT.commands.ContainsHoldOrPress(CommandType.JUMP))
                {
                    BaseMessage jumpDustMessage = new Message_ShowJumpDust(true, _unit.transform.position);
                    jumpDustMessage.Register();

                    //multiply/divide runspeed on jump
                    _unit.unitData.rigidBody2D.velocity = new Vector2(_unit.unitData.rigidBody2D.velocity.x * BaseInitializer.current.fighterDataSO.HorizontalMomentumMultiplierOnRunningJump, _unit.unitData.rigidBody2D.velocity.y);
                    _unit.unitData.airControl.SetMomentum(_unit.unitData.rigidBody2D.velocity.x);
                    _unit.unitData.listNextStates.Add(new LittleRed_Jump_Up(_unit, BaseInitializer.current.fighterDataSO.VerticalJumpForce, 0));
                }
            }
        }
    }
}