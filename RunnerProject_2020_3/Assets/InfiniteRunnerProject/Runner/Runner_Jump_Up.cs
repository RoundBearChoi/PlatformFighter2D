using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_JumpCycle_Orange");

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public Runner_Jump_Up(UnitData data, UserInput input)
        {
            _unitData = data;
            _userInput = input;
        }

        public override void OnEnter()
        {
            _unitData.rigidBody2D.velocity = StaticRefs.gameData.Runner_JumpUp_StartForce;
        }

        public override void OnFixedUpdate()
        {
            if (_unitData.rigidBody2D.velocity.y < 0f && updateCount >= 2)
            {
                _unitData.listNextStates.Add(new Runner_Jump_Fall(_unitData, _userInput));
            }

            UpdateComponents();
        }

        public override void OnLateUpdate()
        {

        }
    }
}