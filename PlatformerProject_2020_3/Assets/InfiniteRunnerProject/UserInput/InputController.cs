using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [System.Serializable]
    public class InputController
    {
        [SerializeField]
        private List<UserInput> _listUserInputs = new List<UserInput>();

        public UserInput AddInput(UnityEngine.InputSystem.Keyboard keyboard, UnityEngine.InputSystem.Mouse mouse, UnityEngine.InputSystem.Gamepad gamepad)
        {
            UserInput userInput = new UserInput(keyboard, mouse, gamepad);
            _listUserInputs.Add(userInput);
            return userInput;
        }

        public void UpdateInputDevices()
        {
            foreach(UserInput input in _listUserInputs)
            {
                input.OnUpdate();
            }
        }

        public UserInput GetLatestUserInput()
        {
            if (_listUserInputs.Count > 0)
            {
                return _listUserInputs[_listUserInputs.Count - 1];
            }

            return null;
        }

        public UserInput GetPCUserInput()
        {
            foreach (UserInput input in _listUserInputs)
            {
                if (input.KEYBOARD != null)
                {
                    return input;
                }
            }

            return null;
        }
    }
}