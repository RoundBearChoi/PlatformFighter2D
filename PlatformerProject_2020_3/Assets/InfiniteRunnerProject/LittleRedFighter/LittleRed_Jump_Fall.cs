using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Jump_Fall : UnitState
    {
        public LittleRed_Jump_Fall(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new LerpHorizontalMomentumOnInput_Air(ownerUnit, BaseInitializer.CURRENT.fighterDataSO.MaxHorizontalAirMomentum));
            _listStateComponents.Add(new UpdateAirMovementOnMomentum(ownerUnit));

            _listStateComponents.Add(new UpdateDirectionOnVelocity(ownerUnit));

            _listStateComponents.Add(new TriggerLittleRedUppercut(ownerUnit, 0));
            _listStateComponents.Add(new TriggerWallSlide(ownerUnit));
            _listStateComponents.Add(new TriggerLittleRedAttackA(ownerUnit, 0));
            _listStateComponents.Add(new TriggerAirDash(ownerUnit, 0));
            _listStateComponents.Add(new TriggerMarioStomp(ownerUnit));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_JUMP_FALL);
        }

        public override void OnFixedUpdate()
        {
            if (ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                if (!ownerUnit.isDummy)
                {
                    BaseMessage showLandingDust = new Message_ShowLandingDust(true, ownerUnit.transform.position, new Vector2(1f, 1f));
                    showLandingDust.Register();
                }

                ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
            }

            FixedUpdateComponents();
        }
    }
}