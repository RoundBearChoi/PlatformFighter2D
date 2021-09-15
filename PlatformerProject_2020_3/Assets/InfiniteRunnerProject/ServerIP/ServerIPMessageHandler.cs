using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ServerIPMessageHandler : BaseMessageHandler
    {
        [SerializeField]
        RB.Server.ServerIP _serverIP = null;

        public ServerIPMessageHandler()
        {
            _serverIP = GameObject.FindObjectOfType<RB.Server.ServerIP>();
            ShowPrivateIP.showIPMessageHandler = this;
            ShowPublicIP.showIPMessageHandler = this;
        }

        public override void HandleMessages()
        {
            foreach (BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.SHOW_PRIVATE_IP)
                {
                    string ip = message.GetStringMessage();
                    Debugger.Log("setting private ip (ui): " + ip);
                    _serverIP.SetLocalIP(ip);
                }

                else if (message.MESSAGE_TYPE == MessageType.SHOW_PUBLIC_IP)
                {
                    string ip = message.GetStringMessage();
                    Debugger.Log("setting public ip (ui): " + ip);
                    _serverIP.SetPublicIP(ip);
                }
            }
        }
    }
}