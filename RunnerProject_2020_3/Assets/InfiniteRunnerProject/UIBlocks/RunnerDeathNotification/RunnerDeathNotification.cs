using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RB
{
    public class RunnerDeathNotification : UIBlock
    {
        private UserInput _userInput = null;

        public override void UpdateUIBlock()
        {
            foreach (KeyPress press in _userInput.listPresses)
            {
                if (press.keyCode == KeyCode.UpArrow)
                {
                    Debugger.Log("ui registers UpArrow key");
                }

                if (press.keyCode == KeyCode.DownArrow)
                {
                    Debugger.Log("ui registers DownArrow key");
                }
            }
        }

        public void SetUserInput(UserInput input)
        {
            _userInput = input;
        }
    }
}