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
                Debug.Log("jump!");
                keyPress_Space.SetPress();
            }
        }
    }
}