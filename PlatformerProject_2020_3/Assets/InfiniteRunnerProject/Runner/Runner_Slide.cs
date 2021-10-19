using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Slide : UnitState
    {
        float _speedMultiplier = 1.4f;

        public Runner_Slide()
        {
            _listStateComponents.Add(new UpdateCollider2DSize(this, new Vector2(0.8f, 2f)));
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, 0.1f, 0.035f));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_SLIDE);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_speedMultiplier > 0f)
            {
                _ownerUnit.unitData.rigidBody2D.velocity = new Vector2(_ownerUnit.unitData.rigidBody2D.velocity.x * _speedMultiplier, _ownerUnit.unitData.rigidBody2D.velocity.y);
                _speedMultiplier = 0f;
            }

            if (fixedUpdateCount % 20 == 0)
            {
                Vector3 offset = new Vector3(1.25f, 0f, 0f);

                if (!_ownerUnit.facingRight)
                {
                    offset *= -1f;
                }

                BaseMessage showSlideDust = new Message_ShowStepDust(true, _ownerUnit.transform.position + offset, new Vector2(1f, 1f), 4);
                showSlideDust.Register();
            }

            if (fixedUpdateCount == 0)
            {
                Vector3 offset = new Vector3(-0.4f, 0f, 0f);

                if (!_ownerUnit.facingRight)
                {
                    offset *= -1f;
                }

                BaseMessage showSlideDust = new Message_ShowSlideDust(true, _ownerUnit.transform.position + offset);
                showSlideDust.Register();
            }

            if (_ownerUnit.USER_INPUT.commands.ContainsPress(CommandType.MOVE_DOWN, false))
            {
                if (_ownerUnit.unitData.rigidBody2D.velocity.x < 1.5f)
                {
                    _ownerUnit.listNextStates.Add(new Runner_Crouch());
                }
            }
            else
            {
                _ownerUnit.listNextStates.Add(new Runner_Slide_GetUp());
            }
        }
    }
}