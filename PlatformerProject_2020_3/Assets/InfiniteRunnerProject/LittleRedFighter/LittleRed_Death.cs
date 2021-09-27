using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Death : UnitState
    {
        public LittleRed_Death(Unit unit)
        {
            ownerUnit = unit;

            //_listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, BaseInitializer.current.fighterDataSO.IdleSlowDownLerpPercentage));
            //_listStateComponents.Add(new UpdateDirectionOnInput(ownerUnit));
            //_listStateComponents.Add(new TriggerJumpUp(ownerUnit));
            //_listStateComponents.Add(new TriggerRunOnGround(ownerUnit));
            //_listStateComponents.Add(new TriggerLittleRedAttackA(ownerUnit));
            //_listStateComponents.Add(new TriggerFallState(ownerUnit));
            //
            //ownerUnit.unitData.airControl.SetMomentum(0f);
            //ownerUnit.unitData.airControl.DashTriggered = false;

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_DEATH);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();
        }
    }
}