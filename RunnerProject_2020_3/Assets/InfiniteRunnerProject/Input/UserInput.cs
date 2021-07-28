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
        private List<KeyControl> _listKeyHolds = new List<KeyControl>();
        private List<ButtonControl> _listButtonHolds = new List<ButtonControl>();

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
                    _listKeyHolds.Add(keyControl);
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

                if (!ContainsButtonHold(buttonControl))
                {
                    _listButtonHolds.Add(buttonControl);
                }
            }

            if (buttonControl.wasReleasedThisFrame)
            {
                if (ContainsButtonHold(buttonControl))
                {
                    RemoveButtonHold(buttonControl);
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
            foreach(KeyControl key in _listKeyHolds)
            {
                if (keyControl == key)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsButtonHold(ButtonControl buttonControl)
        {
            foreach (ButtonControl key in _listButtonHolds)
            {
                if (buttonControl == key)
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveKeyHold(KeyControl keyControl)
        {
            for (int i = _listKeyHolds.Count - 1; i >= 0; i--)
            {
                if (_listKeyHolds[i] == keyControl)
                {
                    _listKeyHolds.RemoveAt(i);
                    return;
                }
            }
        }

        public void RemoveButtonHold(ButtonControl buttonControl)
        {
            for (int i = _listButtonHolds.Count - 1; i >= 0; i--)
            {
                if (_listButtonHolds[i] == buttonControl)
                {
                    _listButtonHolds.RemoveAt(i);
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