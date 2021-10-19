using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CancelJumpForceOnNonPress : StateComponent
    {
        private bool _startPullDown = false;
        private uint _minimumJumpUpFrames = 0;

        public CancelJumpForceOnNonPress(UnitState unitState, uint defaultJumpFrames)
        {
            _unitState = unitState;
            _minimumJumpUpFrames = defaultJumpFrames;
        }

        public override void OnFixedUpdate()
        {
            if (!UNIT_DATA.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                if (!_startPullDown)
                {
                    if (UNIT.iStateController.GetCurrentState().fixedUpdateCount > _minimumJumpUpFrames)
                    {
                        if (!UNIT.USER_INPUT.commands.ContainsPress(CommandType.JUMP, false))
                        {
                            _startPullDown = true;
                        }
                    }
                }
                else
                {
                    if (UNIT_DATA.rigidBody2D.velocity.y > 0f)
                    {
                        float y = Mathf.Lerp(UNIT_DATA.rigidBody2D.velocity.y, 0f, BaseInitializer.CURRENT.fighterDataSO.JumpPullPercentagePerFixedUpdate);
                        UNIT_DATA.rigidBody2D.velocity = new Vector2(UNIT_DATA.rigidBody2D.velocity.x, y);
                    }
                }
            }
        }
    }
}