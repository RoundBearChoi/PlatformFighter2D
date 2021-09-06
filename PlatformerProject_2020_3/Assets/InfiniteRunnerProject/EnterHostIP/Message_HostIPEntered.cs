using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class Message_HostIPEntered : BaseMessage
    {
        public static UIElement uiElement = null;
        string _hostIP = string.Empty;
        InputField _inputField = null;
        

        public Message_HostIPEntered()
        {
            mMessageType = MessageType.HOST_IP_ENTERED;
        }

        public override void Register()
        {
            if (uiElement != null)
            {
                if (_inputField == null)
                {
                    _inputField = uiElement.GetComponentInChildren<InputField>();
                }

                _hostIP = _inputField.text;

                uiElement.messageHandler.Register(this);
            }
        }

        public override string GetStringMessage()
        {
            return _hostIP;
        }
    }
}