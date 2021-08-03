using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Stomped : UnitState
    {
        bool isReset = false;

        public LittleRed_Stomped(Unit unit)
        {
            ownerUnit = unit;

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_STOMPED);
        }

        public override void OnFixedUpdate()
        {
            if (!isReset)
            {
                isReset = true;
                ownerUnit.unitData.spriteAnimations.ManualSetSpriteIndex(0);
            }

            FixedUpdateComponents();

            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
            }
        }
    }
}