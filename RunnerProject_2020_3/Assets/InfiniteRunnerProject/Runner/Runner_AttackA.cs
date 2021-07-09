using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_AttackA : State
    {
        private UserInput _userInput = null;
        private bool _dustCreated = false;
        private static SpriteAnimationSpec _animationSpec = null;

        public static void SetAnimationSpec()
        {
            _animationSpec = UnitCreator.currentSpec;
        }

        public Runner_AttackA(Unit unit, UserInput input)
        {
            _unit = unit;
            _userInput = input;

            _listStateComponents.Add(new LerpRunSpeed(_unit, 2f, 0.05f));
        }

        public override void OnFixedUpdate()
        {
            if (!_dustCreated)
            {
                _dustCreated = true;

                //Units.instance.AddCreator(new StepDust_Creator(Stage.currentStage.transform));
                //Units.instance.ProcessCreators();
                //Units.instance.GetUnit<StepDust>().transform.position = _unit.transform.position + new Vector3(_unit.transform.right.x * 0.8f, 0f, 0f);
            }

            UpdateComponents();

            if (_unit.unitData.spriteAnimations.currentAnimation.IsOnEnd())
            {
                if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
                {
                    _unit.unitData.listNextStates.Add(new Runner_NormalRun(_unit, _userInput));
                }
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return _animationSpec;
        }
    }
}