using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Run : UnitState
    {
        public LittleRed_Run(Unit unit)
        {
            ownerUnit = unit;

            float runspeed = BaseInitializer.current.fighterDataSO.DefaultRunSpeed;

            if (!ownerUnit.unitData.facingRight)
            {
                runspeed *= -1f;
            }

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, runspeed, BaseInitializer.current.fighterDataSO.RunSpeedLerpPercentage));
            _listStateComponents.Add(new Create_LittleRed_Run_StepDust(ownerUnit));
            _listStateComponents.Add(new SetDefaultAnimationInterval(ownerUnit));

            _listStateComponents.Add(new TriggerIdleOnGround(ownerUnit));
            _listStateComponents.Add(new TriggerGroundRoll(ownerUnit));
            _listStateComponents.Add(new TriggerLittleRedUppercut(ownerUnit, 0));
            _listStateComponents.Add(new TriggerLittleRedAttackA(ownerUnit, 0));
            _listStateComponents.Add(new TriggerFallState(ownerUnit));
            _listStateComponents.Add(new TriggerJumpUp(ownerUnit));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_RUN);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}