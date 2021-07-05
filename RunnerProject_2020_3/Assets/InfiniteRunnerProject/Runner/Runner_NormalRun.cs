using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class Runner_NormalRun : State
    {
        public static bool initialPush = false;

        static Hash128 animationHash;
        static string hashString = string.Empty;
        
        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public override void SetHashString()
        {
            if (string.IsNullOrEmpty(hashString))
            {
                hashString = "Texture_RunCycle_Orange";
                animationHash = Hash128.Compute(hashString);
            }
        }

        public Runner_NormalRun(Unit unit, UserInput userInput)
        {
            _unit = unit;

            _listStateComponents.Add(new NormalRunToFall(_unit, userInput));
            _listStateComponents.Add(new MaintainNormalRunSpeed(_unit));
            _listStateComponents.Add(new NormalRun_OnUserInput(_unit, userInput));
        }

        public override void OnEnter()
        {
            if (!initialPush)
            {
                _unit.unitData.rigidBody2D.velocity = StaticRefs.gameData.Runner_NormalRun_StartForce;
                initialPush = true;
            }
        }

        public override void OnFixedUpdate()
        {
            UpdateComponents();
        }
    }
}