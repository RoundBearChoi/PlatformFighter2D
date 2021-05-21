using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FallThrough : StateComponent
    {
        float _fallLimit = 0f;

        public FallThrough(State state, float fallLimit)
        {
            _state = state;
            _fallLimit = fallLimit;
        }

        public override void Update()
        {
            float fall = StaticRefs.gameData.JumpFall.Evaluate(_state.GetNormalizedTime());
            UnitData data = _state.GetUnitData();

            if (data.unitTransform.position.y > _fallLimit)
            {
                data.verticalVelocity -= fall;
                data.unitTransform.position += new Vector3(data.horizontalVelocity, data.verticalVelocity, 0f);
            }

            if (data.unitTransform.position.y <= _fallLimit)
            {
                data.unitTransform.position = new Vector3(data.unitTransform.position.x, _fallLimit, data.unitTransform.position.z);
            }
        }
    }
}