using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_AttackA : State
    {
        static Hash128 animationHash;
        static string hashString = string.Empty;

        private UserInput _userInput = null;

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public override void SetHashString()
        {
            if (string.IsNullOrEmpty(hashString))
            {
                hashString = StaticRefs.runnerAttackSpriteData.AttackA_SpriteName;
                animationHash = Hash128.Compute(hashString);
            }
        }

        public Runner_AttackA(Unit unit, UserInput input)
        {
            _unit = unit;
            _userInput = input;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.spriteAnimations.currentAnimation.IsOnEnd())
            {
                if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
                {
                    _unit.unitData.listNextStates.Add(new Runner_NormalRun(_unit, _userInput));
                }
            }
        }
    }
}