using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Fall : State
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
                hashString = "Texture_Jump_Fall_Orange";
                animationHash = Hash128.Compute(hashString);
            }
        }

        public Runner_Jump_Fall(Unit unit, UserInput input)
        {
            _unit = unit;
            _userInput = input;
        }

        public override void OnEnter()
        {

        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                Debugger.Log("transitioning back to normalrun");
                _unit.unitData.listNextStates.Add(new Runner_NormalRun(_unit, _userInput));

                //testing dust
                Units.instance.AddCreator(new LandingDust_Creator(Stage.currentStage.transform));
                Units.instance.ProcessCreators();
                Units.instance.GetUnit<LandingDust>().transform.position = _unit.transform.position;
            }

            UpdateComponents();
        }
    }
}