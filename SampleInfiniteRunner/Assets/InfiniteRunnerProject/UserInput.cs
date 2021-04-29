using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UserInput : MonoBehaviour
    {
        public List<KeyPress> listPresses = new List<KeyPress>();

        public void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                KeyPress space;
                space.keyCode = KeyCode.Space;
                listPresses.Add(space);
            }
        }
    }
}