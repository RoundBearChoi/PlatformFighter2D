using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Fall : State
    {
        static Hash128 animationHash = Hash128.Compute("Texture_Jump_Fall_Orange");

        public override Hash128 GetAnimationHash()
        {
            return animationHash;
        }

        public Runner_Jump_Fall(UnitData data, UserInput input)
        {
            _unitData = data;
            _userInput = input;
            _listStateComponents.Add(new FixedFall(this));
        }

        public override void OnEnter()
        {

        }

        public override void OnFixedUpdate()
        {
            foreach(CollisionData data in _unitData.listCollisionStays)
            {
                Ground ground = data.collidingObject.GetComponent<Ground>();

                if (ground != null)
                {
                    _unitData.listNextStates.Add(new Runner_NormalRun(_unitData, _userInput));
                }
            }

            UpdateComponents();
        }
    }
}