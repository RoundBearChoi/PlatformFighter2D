using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Jump_Fall : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public LittleRed_Jump_Fall(Unit unit)
        {
            ownerUnit = unit;
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
            }
        }
    }
}