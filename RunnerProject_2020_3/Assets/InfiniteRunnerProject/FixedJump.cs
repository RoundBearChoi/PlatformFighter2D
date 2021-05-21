using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FixedJump : StateComponent
    {
        public FixedJump(State state)
        {
            _state = state;
        }

        public override void Update()
        {
            float pull = StaticRefs.gameData.JumpPull.Evaluate(_state.GetNormalizedTime());
            
            if (_state.GetUnitData().verticalVelocity >= 0f)
            {
                _state.GetUnitData().unitTransform.position += new Vector3(_state.GetUnitData().horizontalVelocity, _state.GetUnitData().verticalVelocity, 0f);
                _state.GetUnitData().verticalVelocity -= pull;
            }

            if (_state.GetUnitData().verticalVelocity < 0f)
            {
                _state.GetUnitData().verticalVelocity = 0f;
            }
        }
    }
}