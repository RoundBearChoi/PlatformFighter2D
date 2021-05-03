using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RB
{
    public class UserInput
    {
        public List<KeyPress> listPresses = new List<KeyPress>();

        private Keyboard keyboard = null;

        public UserInput()
        {
            keyboard = Keyboard.current;
        }

        public void OnUpdate()
        {
            if (keyboard.spaceKey.wasPressedThisFrame)
            {
                Debugger.Log("space is pressed");
                KeyPress space;
                space.key = KeyboardKey.SPACE;
                listPresses.Add(space);
            }
        }
    }
}