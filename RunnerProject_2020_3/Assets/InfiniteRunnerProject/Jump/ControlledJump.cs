using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ControlledJump : StateComponent
    {
        private UserInput _userInput;

        public ControlledJump(State state, UserInput userInput)
        {
            _state = state;
            _userInput = userInput;
        }

        public override void Update()
        {
            float pull = StaticRefs.gameData.JumpPull.Evaluate(_state.GetNormalizedTime());

            if (_state.GetUnitData().verticalVelocity >= 0f)
            {
                _state.GetUnitData().unitTransform.position += new Vector3(_state.GetUnitData().horizontalVelocity, _state.GetUnitData().verticalVelocity, 0f);
                _state.GetUnitData().verticalVelocity -= pull;

                if (!_userInput.ContainsKeyHold(UserInput.keyboard.spaceKey))
                {
                    _state.GetUnitData().verticalVelocity -= 0.007f;
                }
            }

            if (_state.GetUnitData().verticalVelocity < 0f)
            {
                _state.GetUnitData().verticalVelocity = 0f;
            }
        }
    }
}