using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class QuitAll : UIOption
    {
        public override void OnEnterKey()
        {
            Debugger.Log("quitting game");
            Application.Quit();
        }
    }
}