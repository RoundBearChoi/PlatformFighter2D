using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerHPMessageHandler : BaseMessageHandler
    {
        private RunnerHPBar _hpBar = null;

        public RunnerHPMessageHandler(RunnerHPBar hpBar)
        {
            _hpBar = hpBar;
        }

        public override void HandleMessages()
        {
            foreach(BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.UPDATE_RUNNER_HP_UI)
                {
                    _hpBar.UpdateBar(message.GetFloatMessage());
                }
            }
        }
    }
}