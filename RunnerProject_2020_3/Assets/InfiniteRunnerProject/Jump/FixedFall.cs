using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FixedFall : StateComponent
    {
        public FixedFall(State state)
        {
            _state = state;
        }

        public override void Update()
        {
            //float fall = StaticRefs.gameData.JumpFall.Evaluate(_state.GetNormalizedTime());
            //UnitData data = _state.GetUnitData();
            //
            //if (data.unitTransform.position.y > 0f)
            //{
            //    data.verticalVelocity -= fall;
            //    data.unitTransform.position += new Vector3(data.horizontalVelocity, data.verticalVelocity, 0f);
            //}
            //
            //if (data.unitTransform.position.y <= 0f)
            //{
            //    data.unitTransform.position = new Vector3(data.unitTransform.position.x, 0f, data.unitTransform.position.z);
            //}
        }
    }
}