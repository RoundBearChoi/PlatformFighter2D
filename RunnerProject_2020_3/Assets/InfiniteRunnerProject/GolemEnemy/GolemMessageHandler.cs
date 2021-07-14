using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GolemMessageHandler : BaseMessageHandler
    {
        private Unit _unit = null;

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
                    _unit.unitData.health -= message.GetIntMessage();
                }
            }
        }
    }
}