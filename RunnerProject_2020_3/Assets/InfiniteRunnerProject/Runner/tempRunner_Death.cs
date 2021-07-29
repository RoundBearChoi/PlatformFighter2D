using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class tempRunner_Death : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public tempRunner_Death(Unit unit)
        {
            Debugger.Log("runner is dead");
            ownerUnit = unit;
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnEnter()
        {
            BaseMessage message = new UIMessage(MessageType.RUNNER_IS_DEAD);
            message.Register();

            ownerUnit.transform.position = ownerUnit.transform.position + (Vector3.back * 1f);
            ownerUnit.unitData.rigidBody2D.velocity = new Vector3(0f, 6f, 0f);
            ownerUnit.unitData.boxCollider2D.enabled = false;
        }

        public override void OnFixedUpdate()
        {
            if (ownerUnit.transform.position.y <= -20f)
            {
                ownerUnit.unitData.rigidBody2D.Sleep();
            }
        }
    }
}