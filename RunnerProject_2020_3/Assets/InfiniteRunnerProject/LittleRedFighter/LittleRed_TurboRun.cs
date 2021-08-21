using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_TurboRun : UnitState
    {
        public LittleRed_TurboRun(Unit unit)
        {
            ownerUnit = unit;

            float runspeed = BaseInitializer.current.fighterDataSO.DefaultRunSpeed * 1.3f;

            if (!ownerUnit.unitData.facingRight)
            {
                runspeed *= -1f;
            }

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, runspeed, BaseInitializer.current.fighterDataSO.RunSpeedLerpPercentage));
            _listStateComponents.Add(new TriggerJumpUp(ownerUnit));
            _listStateComponents.Add(new TriggerLittleRedAttackA(ownerUnit));
            _listStateComponents.Add(new TriggerFallState(ownerUnit));
            _listStateComponents.Add(new CreateStepDust(ownerUnit));
            _listStateComponents.Add(new SetAnimationInterval(ownerUnit, 2));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_RUN);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}