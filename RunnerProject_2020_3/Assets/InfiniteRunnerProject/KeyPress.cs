using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct KeyPress
    {
        public KeyPress(KeyCode kCode)
        {
            keyCode = kCode;
        }

        public KeyCode keyCode;
    }
}