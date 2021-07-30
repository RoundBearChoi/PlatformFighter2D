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

            _listStateComponents.Add(new LerpHorizontalMomentumOnInput_Air(ownerUnit, GameInitializer.current.fighterDataSO.MaxHorizontalAirMomentum));
            _listStateComponents.Add(new UpdateDirectionOnVelocity(ownerUnit));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLERED_JUMP_FALL);
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