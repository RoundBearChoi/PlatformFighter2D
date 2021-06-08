using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class Runner_NormalRun : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_RunCycle_Orange");
        public static bool initialPush = false;

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public Runner_NormalRun(UnitData data, UserInput input)
        {
            _unitData = data;
            _userInput = input;
        }

        public override void OnEnter()
        {
            if (!initialPush)
            {
                _unitData.rigidBody2D.velocity = StaticRefs.gameData.Runner_NormalRun_StartForce;
                initialPush = true;
            }
        }

        public override void OnFixedUpdate()
        {
            if (_userInput.ContainsKeyPress(UserInput.keyboard.spaceKey))
            {
                _unitData.listNextStates.Add(new Runner_Jump_Up(_unitData, _userInput));
            }
            else if (_userInput.ContainsButtonPress(UserInput.mouse.leftButton))
            {
                _unitData.listNextStates.Add(new Runner_StraightPunch(_unitData, _userInput));
            }
        }
    }
}