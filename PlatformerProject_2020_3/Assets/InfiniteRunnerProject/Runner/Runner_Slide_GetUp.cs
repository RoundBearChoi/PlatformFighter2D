using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Slide_GetUp : UnitState
    {
        public Runner_Slide_GetUp(Unit unit)
        {
            ownerUnit = unit;
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, 0.05f));
            _listStateComponents.Add(new UpdateCollider2DSize(ownerUnit, new Vector2(0.8f, 3.4f)));

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_SLIDE_GETUP);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                ownerUnit.unitData.listNextStates.Add(new Runner_NormalRun(ownerUnit));
            }
        }
    }
}