using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Idle : UnitState
    {
        public LittleRed_Idle(Unit unit)
        {
            ownerUnit = unit;

            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(ownerUnit, 0f, BaseInitializer.current.fighterDataSO.IdleSlowDownLerpPercentage));
            _listStateComponents.Add(new UpdateDirectionOnInput(ownerUnit));

            _listStateComponents.Add(new TriggerFallState(ownerUnit));
            _listStateComponents.Add(new TriggerRunOnGround(ownerUnit));
            _listStateComponents.Add(new TriggerJumpUp(ownerUnit));
            _listStateComponents.Add(new TriggerGroundRoll(ownerUnit));
            _listStateComponents.Add(new TriggerLittleRedUppercut(ownerUnit, 0));
            _listStateComponents.Add(new TriggerLittleRedAttackA(ownerUnit));
            
            ownerUnit.unitData.airControl.SetMomentum(0f);
            ownerUnit.unitData.airControl.DashTriggered = false;

            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_IDLE);
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            //random blink
            if (ownerUnit.iStateController.GetCurrentState().fixedUpdateCount % 120 == 0)
            {
                //Debugger.Log("blink");
            }
        }
    }
}