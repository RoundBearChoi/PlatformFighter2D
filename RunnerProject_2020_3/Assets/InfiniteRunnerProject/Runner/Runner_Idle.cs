using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Idle : State
    {
        private UserInput _userInput = null;
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Idle(Unit unit, UserInput input)
        {
            _unit = unit;
            _userInput = input;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                //Units.instance.AddCreator(new LandingDust_Creator(Stage.currentStage.transform));
                //Units.instance.ProcessCreators();
                //Units.instance.GetUnit<LandingDust>().transform.position = _unit.transform.position;

                _unit.unitData.listNextStates.Add(new Runner_NormalRun(_unit, _userInput));
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}