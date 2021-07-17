using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Idle : State
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Idle(Unit unit)
        {
            _unit = unit;
        }

        public override void OnFixedUpdate()
        {
            if (_unit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                BaseMessage showLandingDust = new ShowLandingDustMessage(true, _unit.transform.position);
                showLandingDust.Register();

                _unit.unitData.listNextStates.Add(new Runner_NormalRun(_unit));
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }
    }
}