using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UpdateRunnerHP_Message : BaseMessage
    {
        public static UIElement uiElement = null;

        private uint _currentHP = 0;
        private uint _totalHP = 1;
        private float _hpPercentage = 0f;

        public UpdateRunnerHP_Message(uint currentHP, uint totalHP)
        {
            _currentHP = currentHP;
            _totalHP = totalHP;
            _hpPercentage = (float)currentHP / (float)totalHP;
            mMessageType = MessageType.UPDATE_RUNNER_HP_UI;
        }

        public override void Register()
        {
            if (uiElement != null)
            {
                uiElement.messageHandler.Register(this);
            }
        }

        public override float GetFloatMessage()
        {
            return _hpPercentage;
        }
    }
}