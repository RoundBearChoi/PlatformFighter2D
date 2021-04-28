using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class KeyPress
    {
        private KeyCode keyCode = KeyCode.None;
        private bool isPressed = false;

        public KeyPress(KeyCode _keyCode)
        {
            keyCode = _keyCode;
        }

        public bool Pressed()
        {
            return isPressed;
        }

        public void SetPress()
        {
            isPressed = true;
        }
    }
}