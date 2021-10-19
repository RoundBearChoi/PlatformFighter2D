using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_ComboTransitionTo_Smash : UnitState
    {
        public Runner_ComboTransitionTo_Smash(Unit unit)
        {
            _ownerUnit = unit;
            _listStateComponents.Add(new LerpHorizontalSpeed_Air(this, 0.01f, 0.05f));
            _listStateComponents.Add(new LerpVerticalSpeed_Air(this, -0.1f, 0.15f));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_COMBOTRANSITIONTO_SMASH);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_ownerUnit.unitData.rigidBody2D.velocity.y <= 0f)
            {
                _ownerUnit.listNextStates.Add(new Runner_Smash_Air_Fall(_ownerUnit));
            }
        }
    }
}