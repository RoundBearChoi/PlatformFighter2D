using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CancelJumpForceOnNonPress : StateComponent
    {
        private bool _startPullDown = false;
        private uint _minimumJumpUpFrames = 0;

        public CancelJumpForceOnNonPress(Unit unit, uint defaultJumpFrames)
        {
            _unit = unit;
            _minimumJumpUpFrames = defaultJumpFrames;
        }

        public override void OnFixedUpdate()
        {
            if (!_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                if (!_startPullDown)
                {
                    if (_unit.iStateController.GetCurrentState().fixedUpdateCount > _minimumJumpUpFrames)
                    {
                        if (!_unit.USER_INPUT.commands.ContainsHold(CommandType.JUMP))
                        {
                            _startPullDown = true;
                        }
                    }
                }
                else
                {
                    if (_unit.unitData.rigidBody2D.velocity.y > 0f)
                    {
                        float y = Mathf.Lerp(_unit.unitData.rigidBody2D.velocity.y, 0f, BaseInitializer.current.fighterDataSO.JumpPullPercentagePerFixedUpdate);
                        _unit.unitData.rigidBody2D.velocity = new Vector2(_unit.unitData.rigidBody2D.velocity.x, y);
                    }
                }
            }
        }
    }
}