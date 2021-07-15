using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GolemMessageHandler : BaseMessageHandler
    {
        private Unit _unit = null;
        private bool zeroHealthTriggered = false;

        public GolemMessageHandler(Unit unit)
        {
            _unit = unit;
        }

        public override void HandleMessages()
        {
            foreach(BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.WINCE)
                {
                    _unit.unitData.listNextStates.Add(new Golem_Wincing(_unit));
                }
                else if (message.MESSAGE_TYPE == MessageType.TAKE_DAMAGE)
                {
                    _unit.unitData.hp -= message.GetIntMessage();
                }
                else if (message.MESSAGE_TYPE == MessageType.ZERO_HEALTH)
                {
                    if (!zeroHealthTriggered)
                    {
                        zeroHealthTriggered = true;
                        _unit.unitData.listNextStates.Add(new Golem_Death(_unit));
                    }
                }
            }
        }
    }
}