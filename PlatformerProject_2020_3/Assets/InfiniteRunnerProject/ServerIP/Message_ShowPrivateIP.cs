using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class ShowPrivateIP : BaseMessage
    {
        public static BaseMessageHandler showIPMessageHandler = null;

        private string _ip = string.Empty;

        public ShowPrivateIP(string ip)
        {
            _ip = ip;
            mMessageType = MessageType.SHOW_PRIVATE_IP;
        }

        public override void Register()
        {
            if (showIPMessageHandler != null)
            {
                showIPMessageHandler.Register(this);
            }
        }

        public override string GetStringMessage()
        {
            return _ip;
        }
    }
}