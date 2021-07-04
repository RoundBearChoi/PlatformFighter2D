using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Idle : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_PrototypeHero_Idle");

        private UserInput _userInput = null;

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public Runner_Idle(Unit unit, UserInput input)
        {
            _unit = unit;
            _userInput = input;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                //_unit.unitData.listNextStates.Add(new Runner_NormalRun(_unit, _userInput));
            }
        }
    }
}