using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_SampleRunAnimation");
        float _timeInterval = 0.025f;

        public Runner_Jump_Up(UnitData data, UserInput input)
        {
            _unitData = data;
            _userInput = input;

            _listStateComponents.Add(new FixedJump(this));
        }

        public override void OnEnter()
        {
            _unitData.verticalVelocity = StaticRefs.gameData.InitialUpForce;
        }

        public override void Update()
        {
            foreach(StateComponent component in _listStateComponents)
            {
                component.Update();
            }

            if (_unitData.verticalVelocity <= 0f)
            {
                nextState = new Runner_Jump_Fall(_unitData, _userInput);
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