using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Fall : State
    {
        private UserInput _userInput = null;
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Jump_Fall(Unit unit, UserInput input)
        {
            _unit = unit;
            _userInput = input;
        }

        public override void OnEnter()
        {

        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                BaseMessage showLandingDust = new ShowLandingDustMessage(true, _unit.transform.position);
                showLandingDust.Register();

                _unit.unitData.listNextStates.Add(new Runner_NormalRun(_unit, _userInput));
            }

            FixedUpdateComponents();
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}