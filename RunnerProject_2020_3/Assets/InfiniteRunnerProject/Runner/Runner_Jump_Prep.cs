using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Jump_Prep : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Jump_Prep(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new TriggerAirDownSmash(unit));
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
            FixedUpdateComponents();

            if (ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                BaseMessage showLandingDust = new ShowLandingDust_Message(true, ownerUnit.transform.position);
                showLandingDust.Register();

                ownerUnit.unitData.listNextStates.Add(new Runner_NormalRun(ownerUnit));
            }
        }
    }
}