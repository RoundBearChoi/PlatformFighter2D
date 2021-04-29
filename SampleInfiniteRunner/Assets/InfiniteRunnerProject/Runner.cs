using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner : MonoBehaviour
    {
        private UserInput userInput = null;

        public StateController stateController = null;

        public void SetUserInput(UserInput _userInput)
        {
            userInput = _userInput;
        }

        private void Start()
        {
            stateController = new StateController(new Runner_Idle());
        }

        public void OnFixedUpdate()
        {
            stateController.UpdateState();

            //temp
            Vector3 newPosition = new Vector3(this.transform.position.x + 0.01f, 0f, 0f);
            this.transform.position = newPosition;

            foreach(KeyPress k in userInput.listPresses)
            {
                if (k.keyCode == KeyCode.Space)
                {
                    Debugger.Log("space pressed");
                }
            }
        }
    }
}