using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Death_Down : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_SampleDeathAnimation");
        float _timeInterval = 0.05f;

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public Runner_Death_Down(UnitData unitData)
        {
            _unitData = unitData;
            _listStateComponents.Add(new FallThrough(this, -10f));
        }

        public override void OnEnter()
        {
            //_unitData.horizontalVelocity = 0f;
        }

        public override void OnFixedUpdate()
        {
            if (_unitData.unitTransform.position.y > -10)
            {
                UpdateComponents();
            }
        }

        public override float GetNormalizedTime()
        {
            return _timeInterval * updateCount;
        }
    }
}