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
            _listStateComponents.Add(new TriggerIdleOnGround(ownerUnit));
            _listStateComponents.Add(new TriggerLittleRedUppercut(ownerUnit, 0));
            _listStateComponents.Add(new TriggerLittleRedAttackA(ownerUnit));
            _listStateComponents.Add(new TriggerFallState(ownerUnit));
            _listStateComponents.Add(new TriggerJumpUp(ownerUnit));
            _listStateComponents.Add(new CreateStepDust(ownerUnit));
            _listStateComponents.Add(new SetDefaultAnimationInterval(ownerUnit));

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_RUN);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            //speed up
            //if (fixedUpdateCount > 50)
            //{
            //    Debugger.Log("trigger turbo run");
            //    ownerUnit.unitData.listNextStates.Add(new LittleRed_TurboRun(ownerUnit));
            //}
        }
    }
}