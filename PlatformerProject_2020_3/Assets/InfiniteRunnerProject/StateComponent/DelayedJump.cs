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

        public DelayedJump(Unit unit, float jumpForce, uint jumpFrame)
        {
            _unit = unit;
            _jumpForce = jumpForce;
            _jumpFrame = jumpFrame;
        }

        public override void OnFixedUpdate()
        {
            SpriteAnimation ani = _unit.unitData.spriteAnimations.GetCurrentAnimation();

            if (ani != null)
            {
                if (!_jumped)
                {
                    if (ani.SPRITE_INDEX >= _jumpFrame)
                    {
                        _jumped = true;
                        _unit.unitData.rigidBody2D.velocity = new Vector2(_unit.unitData.rigidBody2D.velocity.x * BaseInitializer.current.fighterDataSO.HorizontalJumpVelocityMultiplier, _jumpForce);
                    }
                }
            }
        }
    }
}