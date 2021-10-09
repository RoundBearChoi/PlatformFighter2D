using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : UnitState
    {
        private bool _startPullDown = false;

        public Runner_Jump_Up(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new TriggerAirDownSmash(unit));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_JUMP_UP);
        }

        public override void OnEnter()
        {
            ownerUnit.unitData.rigidBody2D.velocity = BaseInitializer.current.runnerDataSO.Runner_JumpForce;
        }

        public override void OnFixedUpdate()
        {

            FixedUpdateComponents();

            if (!_startPullDown)
            {
                if (!ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.JUMP, false))
                {
                    _startPullDown = true;
                }
            }
            else
            {
                if (ownerUnit.unitData.rigidBody2D.velocity.y > 0f)
                {
                    float y = Mathf.Lerp(ownerUnit.unitData.rigidBody2D.velocity.y, 0f, BaseInitializer.current.runnerDataSO.JumpPullPercentagePerFixedUpdate);
                    ownerUnit.unitData.rigidBody2D.velocity = new Vector2(ownerUnit.unitData.rigidBody2D.velocity.x, y);
                }
            }

            if (fixedUpdateCount == 0)
            {
                BaseMessage jumpDustMessage = new Message_ShowJumpDust(true, ownerUnit.transform.position);
                jumpDustMessage.Register();
            }

            if (ownerUnit.unitData.rigidBody2D.velocity.y <= 0f && fixedUpdateCount >= 2)
            {
                ownerUnit.unitData.listNextStates.Add(new Runner_Jump_Fall(ownerUnit));
            }

        }

        public override void OnLateUpdate()
        {

        }
    }
}