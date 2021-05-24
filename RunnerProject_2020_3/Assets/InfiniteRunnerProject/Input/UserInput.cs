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
        private List<KeyControl> _listHolds = new List<KeyControl>();

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

        public void ClearPressDictionary()
        {
            _dicPresses.Clear();
        }
    }
}