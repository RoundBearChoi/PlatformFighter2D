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
            if (_listUserInputs.Count < (int)InputType.PLAYER_FOUR)
            {
                InputType inputType = (InputType)(_listUserInputs.Count + 1);
                _listUserInputs.Add(new UserInput(inputType, keyboard, mouse, gamepad));
                return _listUserInputs[_listUserInputs.Count - 1];
            }

            return null;
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

        public UserInput GetUserInput(InputType inputType)
        {
            foreach(UserInput input in _listUserInputs)
            {
                if (input.INPUT_TYPE == inputType)
                {
                    return input;
                }
            }

            return null;
        }

        public int GetCount()
        {
            return _listUserInputs.Count;
        }
    }
}