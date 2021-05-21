using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Fall : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_SampleRunAnimation");
        float _timeInterval = 0.025f;

        public Runner_Jump_Fall(UnitData data, UserInput input)
        {
            _unitData = data;
            _userInput = input;
            _listStateComponents.Add(new FixedFall(this));
        }

        public override void OnEnter()
        {
            _unitData.verticalVelocity = 0;
        }

        public override void Update()
        {
            UpdateComponents();

            if (_unitData.unitTransform.position.y <= 0f)
            {
                nextState = new Runner_NormalRun(_unitData, _userInput);
            }
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