using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DelayedJump : StateComponent
    {
        private float _jumpForce = 0;
        private uint _jumpFrame = 0;
        private bool _jumped = false;

        public DelayedJump(UnitState unitState, float jumpForce, uint jumpFrame)
        {
            _unitState = unitState;
            _jumpForce = jumpForce;
            _jumpFrame = jumpFrame;
        }

        public override void OnFixedUpdate()
        {
            SpriteAnimation ani = UNIT.spriteAnimations.GetCurrentAnimation();

            if (ani != null)
            {
                if (!_jumped)
                {
                    if (ani.SPRITE_INDEX >= _jumpFrame)
                    {
                        _jumped = true;
                        UNIT_DATA.rigidBody2D.velocity = new Vector2(UNIT_DATA.rigidBody2D.velocity.x * BaseInitializer.CURRENT.fighterDataSO.HorizontalJumpVelocityMultiplier, _jumpForce);
                    }
                }
            }
        }
    }
}