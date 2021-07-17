using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerMessageHandler : BaseMessageHandler
    {
        private Unit _unit = null;
        private bool _zeroHealthTriggered = false;

        public RunnerMessageHandler(Unit unit)
        {
            _unit = unit;
        }

        public override void HandleMessages()
        {
            foreach (BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.WINCE)
                {
                    _unit.unitData.listNextStates.Add(new Runner_Wincing(_unit));
                }
                else if (message.MESSAGE_TYPE == MessageType.TAKE_DAMAGE)
                {
                    _unit.unitData.hp -= message.GetUnsignedIntMessage();
                }
                else if (message.MESSAGE_TYPE == MessageType.ZERO_HEALTH)
                {
                    if (!_zeroHealthTriggered)
                    {
                        _zeroHealthTriggered = true;
                        _unit.unitData.listNextStates.Add(new Runner_Death(_unit));
                    }
                }
            }
        }
    }
}