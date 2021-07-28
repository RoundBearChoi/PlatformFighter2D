using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;
        private bool _startPullDown = false;

        public Runner_Jump_Up(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new TriggerAirDownSmash(unit));
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnEnter()
        {
            ownerUnit.unitData.rigidBody2D.velocity = GameInitializer.current.gameDataSO.Runner_JumpUp_StartForce;
        }

        public override void OnFixedUpdate()
        {

            FixedUpdateComponents();

            if (!_startPullDown)
            {
                if (!GameInitializer.current.GetStage().USER_INPUT.ContainsKeyHold(UserInput.keyboard.spaceKey))
                {
                    _startPullDown = true;
                }
            }
            else
            {
                if (ownerUnit.unitData.rigidBody2D.velocity.y > 0f)
                {
                    float y = Mathf.Lerp(ownerUnit.unitData.rigidBody2D.velocity.y, 0f, GameInitializer.current.gameDataSO.JumpPullPercentagePerFixedUpdate);
                    ownerUnit.unitData.rigidBody2D.velocity = new Vector2(ownerUnit.unitData.rigidBody2D.velocity.x, y);
                }
            }

            if (fixedUpdateCount == 0)
            {
                BaseMessage jumpDustMessage = new ShowJumpDust_Message(true, ownerUnit.transform.position);
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