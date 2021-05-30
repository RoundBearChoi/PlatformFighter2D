using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Death : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_SampleDeathAnimation");

        public Runner_Death(UnitData unitData)
        {
            Debugger.Log("runner is dead");
            _unitData = unitData;
        }

        public override void OnEnter()
        {
            IMessage message = new UIMessage("runner is dead");
            message.Register();

            _unitData.unitTransform.position = _unitData.unitTransform.position + (Vector3.back * 1f);
            _unitData.rigidBody2D.velocity = new Vector3(0f, 6f, 0f);
            _unitData.boxCollider2D.enabled = false;
        }

        public override void Update()
        {
            if (_unitData.unitTransform.position.y <= -20f)
            {
                _unitData.rigidBody2D.Sleep();
            }
        }

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }
    }
}