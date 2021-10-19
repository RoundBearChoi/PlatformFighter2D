using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : UnitState
    {
        private bool _startPullDown = false;

        public Runner_Jump_Up()
        {
            _listStateComponents.Add(new TriggerAirDownSmash(this));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_JUMP_UP);
        }

        public override void OnEnter()
        {
            _ownerUnit.unitData.rigidBody2D.velocity = BaseInitializer.CURRENT.runnerDataSO.Runner_JumpForce;
        }

        public override void OnFixedUpdate()
        {

            FixedUpdateComponents();

            if (!_startPullDown)
            {
                if (!_ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.JUMP, false))
                {
                    _startPullDown = true;
                }
            }
            else
            {
                if (_ownerUnit.unitData.rigidBody2D.velocity.y > 0f)
                {
                    float y = Mathf.Lerp(_ownerUnit.unitData.rigidBody2D.velocity.y, 0f, BaseInitializer.CURRENT.runnerDataSO.JumpPullPercentagePerFixedUpdate);
                    _ownerUnit.unitData.rigidBody2D.velocity = new Vector2(_ownerUnit.unitData.rigidBody2D.velocity.x, y);
                }
            }

            if (fixedUpdateCount == 0)
            {
                BaseMessage jumpDustMessage = new Message_ShowJumpDust(true, _ownerUnit.transform.position);
                jumpDustMessage.Register();
            }

            if (_ownerUnit.unitData.rigidBody2D.velocity.y <= 0f && fixedUpdateCount >= 2)
            {
                _ownerUnit.listNextStates.Add(new Runner_Jump_Fall());
            }

        }

        public override void OnLateUpdate()
        {

        }
    }
}