using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RB
{
    public class RunnerDeathNotification : UIBlock
    {
        private UserInput _userInput = null;
        private AfterDeathSelection afterDeathSelection = AfterDeathSelection.RETURN_TO_MENU;

        public override void UpdateUIBlock()
        {
            foreach (KeyPress press in _userInput.listPresses)
            {
                if (press.keyCode == KeyCode.UpArrow)
                {
                    afterDeathSelection++;
                    Debugger.Log("afterDeathSelection: " + afterDeathSelection.ToString());
                }

                if (press.keyCode == KeyCode.DownArrow)
                {
                    afterDeathSelection--;
                    Debugger.Log("afterDeathSelection: " + afterDeathSelection.ToString());
                }
            }

            if (afterDeathSelection >= AfterDeathSelection.COUNT)
            {
                afterDeathSelection = AfterDeathSelection.RETURN_TO_MENU;
                Debugger.Log("afterDeathSelection: " + afterDeathSelection.ToString());
            }

            if (afterDeathSelection < AfterDeathSelection.RETURN_TO_MENU)
            {
                afterDeathSelection = AfterDeathSelection.RESTART_GAME;
                Debugger.Log("afterDeathSelection: " + afterDeathSelection.ToString());
            }
        }

        public void SetUserInput(UserInput input)
        {
            _userInput = input;
        }
    }
}