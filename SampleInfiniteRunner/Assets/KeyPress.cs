using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class KeyPress
    {
        public KeyCode keyCode = KeyCode.None;
        public bool isPressed = false;
        public bool isProcessed = false;

        public KeyPress(KeyCode _keyCode)
        {
            keyCode = _keyCode;
        }
    }
}