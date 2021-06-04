using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Up : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_JumpCycle_Orange");
        float _timeInterval = 0.025f;

        public Runner_Jump_Up(UnitData data, UserInput input)
        {
            _unitData = data;
            _userInput = input;
        }

        public override void OnEnter()
        {
            _unitData.rigidBody2D.velocity = StaticRefs.gameData.Runner_JumpUp_StartForce;
        }

        public override void Update()
        {
            if (updateCount == 2)
            {
                _unitData.currentGround = null;
            }
            
            UpdateComponents();
        }

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public override float GetNormalizedTime()
        {
            return _timeInterval * updateCount;
        }
    }
}