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

        public override void ProcessMessages()
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
            }
        }
    }
}