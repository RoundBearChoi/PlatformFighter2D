using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Slide : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        float _speedMultiplier = 1.4f;

        public Runner_Slide(Unit unit)
        {
            ownerUnit = unit;
            _listStateComponents.Add(new UpdateCollider2DSize(ownerUnit, new Vector2(0.8f, 2f)));
            _listStateComponents.Add(new LerpRunSpeedOnFlatGround(ownerUnit, 0.1f, 0.035f));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_speedMultiplier > 0f)
            {
                ownerUnit.unitData.rigidBody2D.velocity = new Vector2(ownerUnit.unitData.rigidBody2D.velocity.x * _speedMultiplier, ownerUnit.unitData.rigidBody2D.velocity.y);
                _speedMultiplier = 0f;
            }

            if (fixedUpdateCount % 20 == 0)
            {
                Vector3 offset = new Vector3(1.25f, 0f, 0f);

                if (!ownerUnit.unitData.facingRight)
                {
                    offset *= -1f;
                }

                BaseMessage showSlideDust = new ShowStepDustMessage(true, ownerUnit.transform.position + offset);
                showSlideDust.Register();
            }

            if (fixedUpdateCount == 0)
            {
                Vector3 offset = new Vector3(-0.4f, 0f, 0f);

                if (!ownerUnit.unitData.facingRight)
                {
                    offset *= -1f;
                }

                BaseMessage showSlideDust = new ShowSlideDust_Message(true, ownerUnit.transform.position + offset);
                showSlideDust.Register();
            }

            if (!Stage.currentStage.USER_INPUT.ContainsKeyHold(UserInput.keyboard.sKey) ||
                ownerUnit.unitData.rigidBody2D.velocity.x < 1.5f)
            {
                //getup if down ISN'T held
                if (!Stage.currentStage.USER_INPUT.ContainsKeyHold(UserInput.keyboard.sKey))
                {
                    ownerUnit.unitData.listNextStates.Add(new Runner_Slide_GetUp(ownerUnit));
                }
                else
                {
                    ownerUnit.unitData.listNextStates.Add(new Runner_Crouch(ownerUnit));
                }
            }
        }
    }
}