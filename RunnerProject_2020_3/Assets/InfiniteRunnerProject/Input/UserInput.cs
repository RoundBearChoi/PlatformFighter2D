using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class UserInput
    {
        private Dictionary<KeyControl, int> _dicKeyPresses = new Dictionary<KeyControl, int>();
        private Dictionary<ButtonControl, int> _dicButtonPresses = new Dictionary<ButtonControl, int>();
        private List<KeyControl> _listHolds = new List<KeyControl>();

        public static Keyboard keyboard = null;
        public static Mouse mouse = null;

        public UserInput()
        {
            keyboard = Keyboard.current;
            mouse = Mouse.current;
        }

        void UpdateKeyPress(KeyControl keyControl)
        {
            if (keyControl.wasPressedThisFrame)
            {
                if (_dicKeyPresses.ContainsKey(keyControl))
                {
                    _dicKeyPresses[keyControl]++;
                }
                else
                {
                    _dicKeyPresses.Add(keyControl, 1);
                }

                if (!ContainsKeyHold(keyControl))
                {
                    _listHolds.Add(keyControl);
                }
            }

            if (keyControl.wasReleasedThisFrame)
            {
                if (ContainsKeyHold(keyControl))
                {
                    RemoveKeyHold(keyControl);
                }
            }
        }

        void UpdateButtonPress(ButtonControl buttonControl)
        {
            if (buttonControl.wasPressedThisFrame)
            {
                if (_dicButtonPresses.ContainsKey(buttonControl))
                {
                    _dicButtonPresses[buttonControl]++;
                }
                else
                {
                    _dicButtonPresses.Add(buttonControl, 1);
                }
            }
        }

        public void OnUpdate()
        {
            UpdateKeyPress(keyboard.upArrowKey);
            UpdateKeyPress(keyboard.downArrowKey);

            UpdateKeyPress(keyboard.sKey);

            UpdateKeyPress(keyboard.f5Key);
            UpdateKeyPress(keyboard.f6Key);
            UpdateKeyPress(keyboard.f10Key);
            UpdateKeyPress(keyboard.spaceKey);

            UpdateButtonPress(mouse.leftButton);
            UpdateButtonPress(mouse.rightButton);
        }

        public bool ContainsKeyPress(KeyControl keyControl)
        {
            return _dicKeyPresses.ContainsKey(keyControl);
        }

        public bool ContainsButtonPress(ButtonControl buttonControl)
        {
            return _dicButtonPresses.ContainsKey(buttonControl);
        }

        public bool ContainsKeyHold(KeyControl keyControl)
        {
            foreach(KeyControl key in _listHolds)
            {
                if (keyControl == key)
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveKeyHold(KeyControl keyControl)
        {
            for (int i = _listHolds.Count - 1; i >= 0; i--)
            {
                if (_listHolds[i] == keyControl)
                {
                    _listHolds.RemoveAt(i);
                    return;
                }
            }
        }

        public void ClearKeyDictionary()
        {
            _dicKeyPresses.Clear();
        }

        public void ClearButtonDictionary()
        {
            _dicButtonPresses.Clear();
        }
    }
}