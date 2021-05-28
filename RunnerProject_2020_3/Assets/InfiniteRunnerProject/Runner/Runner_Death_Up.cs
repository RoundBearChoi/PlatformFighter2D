using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Death_Up : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_SampleDeathAnimation");
        float _timeInterval = 0.05f;

        public Runner_Death_Up(UnitData unitData)
        {
            Debugger.Log("runner is dead");
            _unitData = unitData;
            _listStateComponents.Add(new FixedJump(this));
        }

        public override void OnEnter()
        {
            //_unitData.verticalVelocity = StaticRefs.gameData.InitialUpForce;
            //_unitData.horizontalVelocity = 0f;

            IMessage message = new UIMessage("runner is dead");
            message.Register();
        }

        public override void Update()
        {
            UpdateComponents();

            //if (_unitData.verticalVelocity <= 0f)
            //{
            //    _unitData.listNextStates.Add(new Runner_Death_Down(_unitData));
            //}
        }

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public override float GetNormalizedTime()
        {
            return _timeInterval * updateCount;
        }
    }
}