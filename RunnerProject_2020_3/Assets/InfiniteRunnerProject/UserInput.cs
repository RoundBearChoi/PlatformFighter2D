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
            if (keyboard.f5Key.wasPressedThisFrame)
            {
                KeyPress f5 = new KeyPress(KeyCode.F5);
                listPresses.Add(f5);
            }

            if (keyboard.spaceKey.wasPressedThisFrame)
            {
                KeyPress space = new KeyPress(KeyCode.Space);
                listPresses.Add(space);
            }
        }
    }
}