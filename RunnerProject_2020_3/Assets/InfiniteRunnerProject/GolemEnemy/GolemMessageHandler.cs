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
                Debugger.Log("message received by golem!");
            }
        }
    }
}