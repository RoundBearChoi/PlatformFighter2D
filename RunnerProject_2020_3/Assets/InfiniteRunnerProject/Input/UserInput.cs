using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class UserInput
    {
        private Dictionary<KeyControl, int> _dicPresses = new Dictionary<KeyControl, int>();
        private Dictionary<KeyControl, int> _dicHold = new Dictionary<KeyControl, int>();

        public static Keyboard keyboard = null;

        public UserInput()
        {
            keyboard = Keyboard.current;
        }

        void UpdateKeyPress(KeyControl keyControl)
        {
            if (keyControl.wasPressedThisFrame)
            {
                if (_dicPresses.ContainsKey(keyControl))
                {
                    _dicPresses[keyControl]++;
                }
                else
                {
                    _dicPresses.Add(keyControl, 1);
                }

                if (!_dicHold.ContainsKey(keyControl))
                {
                    _dicHold.Add(keyControl, 0);
                }
            }

            if (keyControl.wasReleasedThisFrame)
            {
                if (_dicHold.ContainsKey(keyControl))
                {
                    _dicHold.Remove(keyControl);
                }
            }
        }

        public void OnUpdate()
        {
            UpdateKeyPress(keyboard.upArrowKey);
            UpdateKeyPress(keyboard.downArrowKey);
            UpdateKeyPress(keyboard.f5Key);
            UpdateKeyPress(keyboard.f6Key);
            UpdateKeyPress(keyboard.spaceKey);
        }

        public bool ContainsKeyPress(KeyControl keyControl)
        {
            return _dicPresses.ContainsKey(keyControl);
        }

        public bool ContainsKeyHold(KeyControl keyControl)
        {
            return _dicHold.ContainsKey(keyControl);
        }

        public void ClearPressDictionary()
        {
            _dicPresses.Clear();
        }
    }
}