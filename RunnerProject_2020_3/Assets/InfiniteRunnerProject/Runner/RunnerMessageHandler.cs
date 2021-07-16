using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerMessageHandler : BaseMessageHandler
    {
        private Unit _unit = null;

        public RunnerMessageHandler(Unit unit)
        {
            _unit = unit;
        }

        public override void HandleMessages()
        {
            foreach (BaseMessage message in _listMessages)
            {
                Debugger.Log("received!");
            }
        }
    }
}