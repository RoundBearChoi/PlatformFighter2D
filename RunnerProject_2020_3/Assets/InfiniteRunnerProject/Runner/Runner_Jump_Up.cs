using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : State
    {
        private UserInput _userInput = null;
        private static SpriteAnimationSpec _animationSpec = null;

        public static void SetAnimationSpec()
        {
            _animationSpec = UnitCreator.currentSpec;
        }

        public Runner_Jump_Up(Unit unit, UserInput input)
        {
            _unit = unit;
            _userInput = input;
        }

        public override void OnEnter()
        {
            _unit.unitData.rigidBody2D.velocity = StaticRefs.gameData.Runner_JumpUp_StartForce;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.rigidBody2D.velocity.y < 0f && updateCount >= 2)
            {
                _unit.unitData.listNextStates.Add(new Runner_Jump_Fall(_unit, _userInput));
            }

            UpdateComponents();
        }

        public override void OnLateUpdate()
        {

        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return _animationSpec;
        }
    }
}