using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Death_Down : State
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
                hashString = "Texture_SampleDeathAnimation";
                animationHash = Hash128.Compute(hashString);
            }
        }

        public Runner_Death_Down(Unit unit)
        {
            _unit = unit;
        }

        public override void OnEnter()
        {

        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.unitTransform.position.y > -10)
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