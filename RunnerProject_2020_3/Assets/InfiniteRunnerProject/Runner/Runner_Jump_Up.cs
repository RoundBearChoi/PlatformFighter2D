using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : State
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
                hashString = StaticRefs.runnerMovementSpriteData.Jump_SpriteName;
                animationHash = Hash128.Compute(hashString);
            }
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
    }
}