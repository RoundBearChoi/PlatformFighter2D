using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RB
{
    [System.Serializable]
    public class InputController
    {
        [SerializeField]
        private List<UserInput> _listUserInputs = new List<UserInput>();

        public static UserInput centralUserInput = null;

        public void InitCentralUserInput()
        {
            Keyboard keyboard = Keyboard.current;
            Mouse mouse = Mouse.current;
            Gamepad gamepad = null;

            if (Gamepad.all.Count > 0)
            {
                gamepad = Gamepad.all[0];
            }

            centralUserInput = new UserInput(keyboard, mouse, gamepad);
        }

        public UserInput AddInput(Keyboard keyboard, Mouse mouse, Gamepad gamepad)
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
    }
}