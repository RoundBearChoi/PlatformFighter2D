using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner : MonoBehaviour
    {
        private UserInput userInput = null;

        public void SetUserInput(UserInput _userInput)
        {
            userInput = _userInput;
        }

        public void OnFixedUpdate()
        {
            Vector3 newPosition = new Vector3(this.transform.position.x + 0.01f, 0f, 0f);
            this.transform.position = newPosition;

            foreach(KeyPress k in userInput.listPresses)
            {
                if (k.keyCode == KeyCode.Space)
                {
                    Debug.Log("space pressed");
                }
            }

            userInput.listPresses.Clear();
        }
    }
}