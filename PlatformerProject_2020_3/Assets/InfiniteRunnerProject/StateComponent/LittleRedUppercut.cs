using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRedUppercut : UnitState
    {
        private bool initialFaceRight = true;

        public LittleRedUppercut(Unit unit)
        {
            ownerUnit = unit;
            initialFaceRight = unit.unitData.facingRight;

            //_listStateComponents.Add(new CancelJumpForceOnNonPress(ownerUnit, 0));
            //_listStateComponents.Add(new LerpHorizontalMomentumOnInput_Air(ownerUnit, BaseInitializer.current.fighterDataSO.MaxHorizontalAirMomentum));
            //_listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, BaseInitializer.current.fighterDataSO.AttackASlowDownPercentage));
            //_listStateComponents.Add(new OverlapBoxCollision(ownerUnit, BaseInitializer.current.GetOverlapBoxCollisionData(OverlapBoxDataType.LITTLE_RED_ATTACK_A)));
            //_listStateComponents.Add(new TriggerMarioStomp(ownerUnit));
            //_listStateComponents.Add(new TriggerLittleRedAttackB(ownerUnit));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_UPPERCUT);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.spriteAnimations.GetCurrentAnimation().IsOnEnd())
            {
                if (initialFaceRight)
                {
                    ownerUnit.unitData.facingRight = false;
                }
                else
                {
                    ownerUnit.unitData.facingRight = true;
                }

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