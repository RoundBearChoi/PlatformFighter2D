using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Jump_Fall : UnitState
    {
        public LittleRed_Jump_Fall()
        {
            _listStateComponents.Add(new LerpHorizontalMomentumOnInput_Air(this, BaseInitializer.CURRENT.fighterDataSO.MaxHorizontalAirMomentum));
            _listStateComponents.Add(new UpdateAirMovementOnMomentum(this));

            _listStateComponents.Add(new UpdateDirectionOnVelocity(this));

            _listStateComponents.Add(new TriggerLittleRedUppercut(this, 0));
            _listStateComponents.Add(new TriggerWallSlide(this));
            _listStateComponents.Add(new TriggerLittleRedAttackA(this, 0));
            _listStateComponents.Add(new TriggerAirDash(this, 0));
            _listStateComponents.Add(new TriggerMarioStomp(this));

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

                ownerUnit.listNextStates.Add(new LittleRed_Idle());
            }

            FixedUpdateComponents();
        }
    }
}