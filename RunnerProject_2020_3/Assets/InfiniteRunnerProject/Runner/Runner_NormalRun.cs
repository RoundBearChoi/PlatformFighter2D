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
        
        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public Runner_NormalRun(Unit unit, UserInput input)
        {
            _unit = unit;
            _userInput = input;
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
            //in the air
            if (_unit.unitData.collisionStays.GetCount() == 0)
            {
                //falling
                if (_unit.unitData.rigidBody2D.velocity.y < 0f)
                {
                    _unit.unitData.listNextStates.Add(new Runner_Jump_Fall(_unit, _userInput));
                }
            }

            if (IsOnFlatGround())
            {
                float dif = _unit.unitData.rigidBody2D.velocity.x - StaticRefs.gameData.Runner_JumpUp_StartForce.x;

                if (Mathf.Abs(dif) > 0.001f)
                {
                    float x = Mathf.Lerp(_unit.unitData.rigidBody2D.velocity.x, StaticRefs.gameData.Runner_JumpUp_StartForce.x, StaticRefs.gameData.Runner_RunSpeed_LerpRate);

                    _unit.unitData.rigidBody2D.velocity = new Vector2(x, _unit.unitData.rigidBody2D.velocity.y);
                }
            }

            if (_userInput.ContainsKeyPress(UserInput.keyboard.spaceKey))
            {
                _unit.unitData.listNextStates.Add(new Runner_Jump_Up(_unit, _userInput));
            }
            else if (_userInput.ContainsButtonPress(UserInput.mouse.leftButton))
            {
                _unit.unitData.listNextStates.Add(new Runner_StraightPunch(_unit, _userInput));
            }
        }

        bool IsOnFlatGround()
        {
            List<Ground> listGrounds = _unit.unitData.collisionStays.GetTouchingGrounds();

            if (listGrounds.Count == 0)
            {
                return false;
            }

            foreach(Ground ground in listGrounds)
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