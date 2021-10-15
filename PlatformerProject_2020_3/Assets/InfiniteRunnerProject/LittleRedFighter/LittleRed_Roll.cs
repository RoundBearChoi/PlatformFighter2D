using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Roll : UnitState
    {
        public LittleRed_Roll(Unit unit)
        {
            disallowTransitionQueue = true;

            ownerUnit = unit;

            _listStateComponents.Add(new Create_LittleRed_Roll_StepDust(ownerUnit));

            _listStateComponents.Add(new GroundRoll(ownerUnit));
            _listStateComponents.Add(new TriggerMarioStomp(ownerUnit));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_GROUND_ROLL);
        }

        public override void OnFixedUpdate()
        {
            ownerUnit.gameObject.layer = (int)LayerType.GHOSTING_UNIT;

            FixedUpdateComponents();
        }
    }
}