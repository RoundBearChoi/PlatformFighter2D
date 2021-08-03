using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Dash : UnitState
    {
        public LittleRed_Dash(Unit unit)
        {
            ownerUnit = unit;

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_DASH);
        }

        public override void OnEnter()
        {
            float initialMomentum = ownerUnit.unitData.airControl.HORIZONTAL_MOMENTUM * 0.5f;
            ownerUnit.unitData.airControl.SetMomentum(initialMomentum);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();


        }
    }
}