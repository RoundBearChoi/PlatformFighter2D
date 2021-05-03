using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UserInput
    {
        public List<KeyPress> listPresses = new List<KeyPress>();

        public UserInput()
        {

        }

        public void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                KeyPress f5 = new KeyPress(KeyCode.F5);
                listPresses.Add(f5);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                KeyPress space = new KeyPress(KeyCode.Space);
                listPresses.Add(space);
            }
        }
    }
}