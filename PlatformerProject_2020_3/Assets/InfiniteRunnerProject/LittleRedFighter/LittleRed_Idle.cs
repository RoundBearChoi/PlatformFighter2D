using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed_Idle : UnitState
    {
        public LittleRed_Idle()
        {
            _listStateComponents.Add(new LerpHorizontalSpeed_FlatGround(this, 0f, BaseInitializer.CURRENT.fighterDataSO.IdleSlowDownLerpPercentage));
            _listStateComponents.Add(new UpdateDirectionOnInput(this));

            _listStateComponents.Add(new TriggerFallState(this));
            _listStateComponents.Add(new TriggerRunOnGround(this));
            _listStateComponents.Add(new TriggerJumpUp(this));
            _listStateComponents.Add(new TriggerGroundRoll(this));
            _listStateComponents.Add(new TriggerLittleRedUppercut(this, 0));
            _listStateComponents.Add(new TriggerLittleRedAttackA(this, 0));
            
            _listMatchingSpriteTypes.Add(SpriteType.LITTLE_RED_IDLE);
        }

        public override void OnEnter()
        {
            _ownerUnit.unitData.airControl.SetMomentum(0f);
            _ownerUnit.unitData.airControl.DashTriggered = false;
            _ownerUnit.unitData.airControl.UppercutTriggered = false;
            _ownerUnit.attack_A_Triggered = false;
        }

        public override void OnFixedUpdate()
        {
            FixedUpdateComponents();

            //random blink
            if (_ownerUnit.iStateController.GetCurrentState().fixedUpdateCount % 120 == 0)
            {
                //Debugger.Log("blink");
            }
        }


    }
}