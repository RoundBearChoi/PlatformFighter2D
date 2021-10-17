using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class GameVersion : UIElement
    {
        Text _text = null;

        public override void InitElement()
        {
            _text = this.gameObject.GetComponentInChildren<Text>();
            _text.text = "V" + Application.version;
            Debugger.Log("game version: " + Application.version);
        }
    }
}