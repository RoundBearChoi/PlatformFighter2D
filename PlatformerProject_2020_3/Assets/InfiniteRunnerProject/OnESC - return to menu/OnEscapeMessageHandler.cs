using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class OnEscapeMessageHandler : BaseMessageHandler
    {
        OnESC _onESC = null;

        public OnEscapeMessageHandler()
        {
            _onESC = GameObject.FindObjectOfType<OnESC>();
        }

        public override void HandleMessages()
        {
            foreach (BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.CLEAR_ONESCAPE_CHILD_ELEMENTS)
                {
                    if (_onESC != null)
                    {
                        _onESC.ClearChildElements();
                    }
                }
            }
        }
    }
}