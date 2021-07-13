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
                if (message.MESSAGE_TYPE == MessageType.HITSTOP_REGISTER_ALL)
                {
                    Debugger.Log("hitstopmessage received by units: " + message.GetUnsignedIntMessage() + " frames");

                    foreach (Unit unit in _listUnits)
                    {
                        if (unit.unitUpdater != null)
                        {
                            unit.unitUpdater.AddHitStopFrames(message.GetUnsignedIntMessage());
                        }
                    }
                }
                else if (message.MESSAGE_TYPE == MessageType.SHOW_BLOOD)
                {
                    Stage.currentStage.InstantiateUnit_ByUnitType(UnitType.BLOOD_5, null);
                    Unit blood = Units.instance.GetUnit<Blood_5>();
                    blood.unitData.faceRight = message.GetBoolMessage();
                    blood.transform.position = message.GetVector3Message();
                }
            }
        }
    }
}