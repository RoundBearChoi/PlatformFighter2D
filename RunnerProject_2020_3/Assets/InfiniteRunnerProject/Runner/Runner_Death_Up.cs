using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Death_Up : State
    {
        static Hash128 animationHash;
        static string hashString = string.Empty;

        float _timeInterval = 0.05f;

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public override void SetHashString()
        {
            if (string.IsNullOrEmpty(hashString))
            {
                hashString = StaticRefs.runnerMovementSpriteData.Death_SpriteName;
                animationHash = Hash128.Compute(hashString);
            }
        }

        public Runner_Death_Up(Unit unit)
        {
            Debugger.Log("runner is dead");
            _unit = unit;
        }

        public override void OnEnter()
        {
            IMessage message = new UIMessage("runner is dead");
            message.Register();
        }

        public override void OnFixedUpdate()
        {
            UpdateComponents();
        }

        public override float GetNormalizedTime()
        {
            return _timeInterval * updateCount;
        }
    }
}