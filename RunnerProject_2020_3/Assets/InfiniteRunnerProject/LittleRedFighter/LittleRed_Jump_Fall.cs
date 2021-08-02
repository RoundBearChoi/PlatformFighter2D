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

            _listStateComponents.Add(new LerpHorizontalMomentumOnInput_Air(ownerUnit, GameInitializer.current.fighterDataSO.MaxHorizontalAirMomentum));
            _listStateComponents.Add(new UpdateDirectionOnVelocity(ownerUnit));
            _listStateComponents.Add(new TriggerWallSlide(ownerUnit));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_JUMP_FALL);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            if (ownerUnit.unitData.collisionStays.IsTouchingGround(CollisionType.BOTTOM))
            {
                BaseMessage showLandingDust = new ShowLandingDust_Message(true, ownerUnit.transform.position, new Vector2(1f, 1f));
                showLandingDust.Register();

                ownerUnit.unitData.listNextStates.Add(new LittleRed_Idle(ownerUnit));
            }
        }
    }
}