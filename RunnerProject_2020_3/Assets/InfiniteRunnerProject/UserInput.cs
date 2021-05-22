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
            if (keyboard.upArrowKey.wasPressedThisFrame)
            {
                KeyPress upArrow = new KeyPress(KeyCode.UpArrow);
                listPresses.Add(upArrow);
            }

            if (keyboard.downArrowKey.wasPressedThisFrame)
            {
                KeyPress downArrow = new KeyPress(KeyCode.DownArrow);
                listPresses.Add(downArrow);
            }

            if (keyboard.f5Key.wasPressedThisFrame)
            {
                KeyPress f5 = new KeyPress(KeyCode.F5);
                listPresses.Add(f5);
            }

            if (keyboard.f6Key.wasPressedThisFrame)
            {
                KeyPress f6 = new KeyPress(KeyCode.F6);
                listPresses.Add(f6);
            }

            if (keyboard.spaceKey.wasPressedThisFrame)
            {
                KeyPress space = new KeyPress(KeyCode.Space);
                listPresses.Add(space);
            }
        }
    }
}