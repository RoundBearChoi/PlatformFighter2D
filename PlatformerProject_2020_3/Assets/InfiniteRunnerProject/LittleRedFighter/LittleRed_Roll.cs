using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Roll : UnitState
    {
        public LittleRed_Roll()
        {
            disallowTransitionQueue = true;

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_GROUND_ROLL);
        }

        public override void OnEnter()
        {
            _listStateComponents.Add(new Create_LittleRed_Roll_StepDust(this));
            _listStateComponents.Add(new MidAirRoll(this));
            _listStateComponents.Add(new GroundRoll(this));
            _listStateComponents.Add(new TriggerMarioStomp(this));
        }

        public override void OnFixedUpdate()
        {
            _ownerUnit.gameObject.layer = (int)LayerType.GHOSTING_UNIT;

            FixedUpdateComponents();
        }

        public override void OnExit()
        {
            _ownerUnit.gameObject.layer = (int)LayerType.PHYSICAL_UNIT;
        }
    }
}