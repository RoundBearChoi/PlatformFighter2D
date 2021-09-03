using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Attack_A : UnitState
    {
        public LittleRed_Attack_A(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new CancelJumpForceOnNonPress(ownerUnit, 0));
            _listStateComponents.Add(new LerpHorizontalMomentumOnInput_Air(ownerUnit, BaseInitializer.current.fighterDataSO.MaxHorizontalAirMomentum));
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, BaseInitializer.current.fighterDataSO.AttackASlowDownPercentage));
            _listStateComponents.Add(new OverlapBoxCollision(ownerUnit, BaseInitializer.current.GetOverlapBoxCollisionData(OverlapBoxDataType.LITTLE_RED_ATTACK_A)));
            _listStateComponents.Add(new TriggerMarioStomp(ownerUnit));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_ATTACK_A);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                if (ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
                }
                else
                {
                    ownerUnit.unitData.listNextStates.Add(new LittleRed_Jump_Fall(ownerUnit));
                }
            }
        }
    }
}