using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct KeyPress
    {
        public KeyPress(KeyCode _keyCode)
        {
            keyCode = _keyCode;
        }

        public KeyCode keyCode;
    }
}