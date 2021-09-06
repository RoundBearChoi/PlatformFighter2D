using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class ConnectingToHost : UIElement
    {
        [SerializeField]
        Text _ip = null;

        public override void InitElement()
        {
            _ip.text = RB.Client.BaseClientControl.CURRENT.GetHostIP();
        }

        public override void OnFixedUpdate()
        {
            UpdateSpriteAnimation();
        }
    }
}