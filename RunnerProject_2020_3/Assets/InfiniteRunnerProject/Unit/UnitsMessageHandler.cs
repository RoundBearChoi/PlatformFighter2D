using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UnitsMessageHandler : BaseMessageHandler
    {
        private List<Unit> _listUnits = null;

        public UnitsMessageHandler(List<Unit> listUnits)
        {
            _listUnits = listUnits;
        }

        public override void HandleMessages()
        {
            foreach (BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.HITSTOP_REGISTER)
                {
                    Debugger.Log("hitstopmessage received by units: " + message.GetUnsignedIntMessage() + " frames");

                    foreach (Unit unit in _listUnits)
                    {
                        if (unit.unitType == message.GetUnitTypeMessage())
                        {
                            if (unit.unitUpdater != null)
                            {
                                unit.unitUpdater.AddHitStopFrames(message.GetUnsignedIntMessage());
                            }
                        }
                    }
                }
                else if (message.MESSAGE_TYPE == MessageType.SHOW_BLOOD)
                {
                    Stage.currentStage.InstantiateUnit_ByUnitType(UnitType.BLOOD_5);
                    Unit blood = Units.instance.GetUnit<Blood_5>();
                    blood.unitData.facingRight = message.GetBoolMessage();

                    Vector3 localPos = blood.transform.localPosition;

                    blood.transform.position = message.GetVector3Message() + localPos;
                }
                else if (message.MESSAGE_TYPE == MessageType.SHOW_PARRY_EFFECT)
                {
                    Stage.currentStage.InstantiateUnit_ByUnitType(UnitType.PARRY_EFFECT);
                    Unit parryEffect = Units.instance.GetUnit<ParryEffect>();
                    parryEffect.transform.position = message.GetVector3Message();
                }
                else if (message.MESSAGE_TYPE == MessageType.SHOW_LANDING_DUST)
                {
                    Stage.currentStage.InstantiateUnit_ByUnitType(UnitType.LANDING_DUST);
                    Unit landingDust = Units.instance.GetUnit<LandingDust>();
                    landingDust.transform.position = message.GetVector3Message();
                }
                else if (message.MESSAGE_TYPE == MessageType.SHOW_DASH_DUST)
                {
                    Stage.currentStage.InstantiateUnit_ByUnitType(UnitType.DASH_DUST);
                    Unit dashDust = Units.instance.GetUnit<DashDust>();
                    dashDust.transform.position = message.GetVector3Message();
                }
                else if (message.MESSAGE_TYPE == MessageType.SHOW_STEP_DUST)
                {
                    Stage.currentStage.InstantiateUnit_ByUnitType(UnitType.STEP_DUST);
                    Unit stepDust = Units.instance.GetUnit<StepDust>();
                    stepDust.transform.position = message.GetVector3Message();
                    stepDust.unitData.facingRight = message.GetBoolMessage();
                }
                else if (message.MESSAGE_TYPE == MessageType.SHOW_SLIDE_DUST)
                {
                    Stage.currentStage.InstantiateUnit_ByUnitType(UnitType.SLIDE_DUST);
                    Unit slideDust = Units.instance.GetUnit<SlideDust>();
                    slideDust.transform.position = message.GetVector3Message();
                    slideDust.unitData.facingRight = message.GetBoolMessage();
                }
            }
        }
    }
}