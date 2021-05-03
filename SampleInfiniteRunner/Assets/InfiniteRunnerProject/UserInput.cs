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

            }

            if (keyboard.spaceKey.wasPressedThisFrame)
            {
                Debugger.Log("space is pressed");
                KeyPress space;
                space.keyCode = KeyCode.Space;
                listPresses.Add(space);
            }
        }
    }
}