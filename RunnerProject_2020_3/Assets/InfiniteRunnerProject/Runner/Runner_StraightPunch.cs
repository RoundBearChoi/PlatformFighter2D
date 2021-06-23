using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_StraightPunch : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_StraightPunch");

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public Runner_StraightPunch(UnitData data, UserInput input)
        {
            _unitData = data;
            _userInput = input;
        }

        public override void OnFixedUpdate()
        {
            if (_unitData.spriteAnimations.currentAnimation.IsOnEnd())
            {
                if (_unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
                {
                    _unitData.listNextStates.Add(new Runner_NormalRun(_unitData, _userInput));
                }
            }
        }
    }
}