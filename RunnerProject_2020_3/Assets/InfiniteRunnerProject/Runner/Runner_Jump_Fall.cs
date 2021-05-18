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
        }

        public override void OnEnter()
        {
            _unitData.verticalVelocity = 0;
        }

        public override void Update()
        {
            float fall = StaticRefs.gameData.JumpFall.Evaluate(_timeInterval * updateCount);

            if (_unitData.unitTransform.position.y > 0f)
            {
                _unitData.verticalVelocity -= fall;
                _unitData.unitTransform.position += new Vector3(_unitData.horizontalVelocity, _unitData.verticalVelocity, 0f);
            }
            
            if (_unitData.unitTransform.position.y <= 0f)
            {
                _unitData.unitTransform.position = new Vector3(_unitData.unitTransform.position.x, 0f, _unitData.unitTransform.position.z);
                nextState = StateFactory.Create_Runner_NormalRun(_unitData, _userInput);
            }
        }

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }
    }
}