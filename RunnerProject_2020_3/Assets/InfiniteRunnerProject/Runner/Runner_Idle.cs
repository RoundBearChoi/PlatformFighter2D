using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Idle : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_Idle_Orange");

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public Runner_Idle(UnitData data, UserInput input)
        {
            _unitData = data;
            _userInput = input;
        }

        public override void OnFixedUpdate()
        {
            if (_unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                _unitData.listNextStates.Add(new Runner_NormalRun(_unitData, _userInput));
            }
        }
    }
}