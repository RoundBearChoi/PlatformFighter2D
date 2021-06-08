using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class Runner_NormalRun : State
    {
        public static bool initialPush = false;
        static Hash128 animationHash = Hash128.Compute("Texture_RunCycle_Orange");
        
        List<Ground> _touchingGrounds = new List<Ground>();

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
            if (IsOnFlatGround())
            {
                int n = 0;
            }

            if (_userInput.ContainsKeyPress(UserInput.keyboard.spaceKey))
            {
                _unitData.listNextStates.Add(new Runner_Jump_Up(_unitData, _userInput));
            }
            else if (_userInput.ContainsButtonPress(UserInput.mouse.leftButton))
            {
                _unitData.listNextStates.Add(new Runner_StraightPunch(_unitData, _userInput));
            }
        }

        bool IsOnFlatGround()
        {
            _touchingGrounds.Clear();

            foreach (CollisionData data in _unitData.listCollisionStays)
            {
                Ground ground = data.collidingObject.GetComponent<Ground>();

                if (ground != null)
                {
                    _touchingGrounds.Add(ground);
                }
            }

            if (_touchingGrounds.Count == 0)
            {
                return false;
            }

            foreach(Ground ground in _touchingGrounds)
            {
                if (Mathf.Abs(ground.transform.rotation.z) >= 0.001f)
                {
                    return false;
                }
            }

            return true;
        }
    }
}