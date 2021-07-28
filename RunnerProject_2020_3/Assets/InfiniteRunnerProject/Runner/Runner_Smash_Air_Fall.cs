using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner_Smash_Air_Fall : UnitState
    {
        public static SpriteAnimationSpec animationSpec = null;

        public Runner_Smash_Air_Fall(Unit unit)
        {
            ownerUnit = unit;
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, 0.05f));
            _listStateComponents.Add(new AddCumulativeVelocity(ownerUnit, 1.3f));

            ownerUnit.gameObject.layer = (int)LayerType.GHOSTING_UNIT;
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return animationSpec;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.collisionEnters.IsTouchingGround(CollisionType.BOTTOM) || ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                BaseMessage showSmashDust = new ShowSmashDustMessage(true, ownerUnit.transform.position);
                showSmashDust.Register();

                ownerUnit.unitData.listNextStates.Add(new Runner_Smash_Air_Land(ownerUnit));
            }
        }
    }
}