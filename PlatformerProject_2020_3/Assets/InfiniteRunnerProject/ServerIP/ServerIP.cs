using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB.Server
{
    public class ServerIP : UIElement
    {
        [SerializeField]
        Text _localIP = null;

        [SerializeField]
        Text _publicIP = null;

        public override void InitElement()
        {
            _localIP.text = string.Empty;
            _publicIP.text = string.Empty;
        }

        public void SetLocalIP(string ip)
        {
            _localIP.text = ip;
        }

        public void SetPublicIP(string ip)
        {
            _publicIP.text = ip;
        }
    }
}