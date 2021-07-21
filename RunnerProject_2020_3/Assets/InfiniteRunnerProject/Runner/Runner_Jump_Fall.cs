using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Fall : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Jump_Fall(Unit unit)
        {
            ownerUnit = unit;
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnEnter()
        {

        }

        public override void OnFixedUpdate()
        {
            if (ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                BaseMessage showLandingDust = new ShowLandingDustMessage(true, ownerUnit.transform.position);
                showLandingDust.Register();

                ownerUnit.unitData.listNextStates.Add(new Runner_NormalRun(ownerUnit));
            }

            FixedUpdateComponents();
        }
    }
}