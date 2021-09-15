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
    }
}