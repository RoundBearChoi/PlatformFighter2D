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
        }

        public override void Update()
        {

        }

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }
    }
}