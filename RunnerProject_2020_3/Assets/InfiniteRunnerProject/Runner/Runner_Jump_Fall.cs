using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Fall : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_Jump_Fall_Orange");

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public Runner_Jump_Fall(Unit unit, UserInput input)
        {
            _unit = unit;
            _userInput = input;
            _listStateComponents.Add(new FixedFall(this));
        }

        public override void OnEnter()
        {

        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                _unit.unitData.listNextStates.Add(new Runner_NormalRun(_unit, _userInput));
            }

            UpdateComponents();
        }
    }
}