using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    [System.Serializable]
    public class Presses
    {
        [SerializeField]
        List<Press> _listPresses = new List<Press>();

        public void Add(CommandType commandType, ButtonControl buttonControl)
        {
            if (GetPress(buttonControl) == null)
            {
                _listPresses.Add(new Press(commandType, buttonControl));
            }
            else
            {
                Debugger.Log("button already exists: " + buttonControl.name);
            }
        }

        public Press GetPress(ButtonControl buttonControl)
        {
            foreach (Press p in _listPresses)
            {
                if (p.BUTTON_CONTROL == buttonControl)
                {
                    return p;
                }
            }

            return null;
        }
    }
}