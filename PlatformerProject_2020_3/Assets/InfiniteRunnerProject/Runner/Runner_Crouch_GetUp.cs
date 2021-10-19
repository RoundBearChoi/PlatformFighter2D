using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Crouch_GetUp : UnitState
    {
        public Runner_Crouch_GetUp(Unit unit)
        {
            _ownerUnit = unit;
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, 0f, 0.05f));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_CROUCH_GETUP);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (_ownerUnit.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                _ownerUnit.listNextStates.Add(new Runner_NormalRun());
            }
        }
    }
}