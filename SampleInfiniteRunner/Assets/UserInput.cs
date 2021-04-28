using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UserInput : MonoBehaviour
    {
        public KeyPress keyPress_Space = new KeyPress(KeyCode.Space);

        public void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                keyPress_Space.isPressed = true;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                keyPress_Space.isPressed = false;
                keyPress_Space.isProcessed = false;
            }
        }
    }
}