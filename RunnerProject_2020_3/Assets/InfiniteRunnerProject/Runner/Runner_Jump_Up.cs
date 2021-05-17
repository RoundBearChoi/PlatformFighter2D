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
        }

        public override void OnEnter()
        {
            _unitData.verticalVelocity = StaticRefs.gameData.InitialUpForce;
        }

        public override void Update()
        {
            float pull = StaticRefs.gameData.JumpPull.Evaluate(_timeInterval * updateCount);

            if (_unitData.verticalVelocity >= 0f)
            {
                _unitData.unitTransform.position += new Vector3(_unitData.horizontalVelocity, _unitData.verticalVelocity, 0f);
                _unitData.verticalVelocity -= pull;
            }
            else
            {
                _unitData.verticalVelocity = 0f;
                nextState = StateFactory.Create_Runner_Jump_Fall(_unitData, _userInput);
            }
        }

        public override Hash128 GetHash()
        {
            return animationHash;
        }
    }
}