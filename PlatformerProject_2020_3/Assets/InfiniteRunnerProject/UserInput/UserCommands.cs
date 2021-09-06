using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class UserCommands
    {
        private Dictionary<CommandType, UserCommand> _dicAllCommands = new Dictionary<CommandType, UserCommand>();

        private Dictionary<KeyControl, int> _dicKeyPresses = new Dictionary<KeyControl, int>();
        private Dictionary<ButtonControl, int> _dicButtonPresses = new Dictionary<ButtonControl, int>();
        private List<KeyControl> _listKeyHolds = new List<KeyControl>();
        private List<ButtonControl> _listButtonHolds = new List<ButtonControl>();

        public void AddCommand(UserCommand command)
        {
            if (!_dicAllCommands.ContainsKey(command.COMMAND_TYPE))
            {
                _dicAllCommands.Add(command.COMMAND_TYPE, command);
            }
            else
            {
                _dicAllCommands[command.COMMAND_TYPE] = command;
            }
        }

        public void OnUpdate()
        {
            foreach(KeyValuePair<CommandType, UserCommand> data in _dicAllCommands)
            {
                KeyControl key = data.Value.KEY;
                ButtonControl button = data.Value.BUTTON;

                if (key != null)
                {
                    UpdateKeyPress(key);
                }
                else if (button != null)
                {
                    UpdateButtonPress(button);
                }
            }
        }

        public void ClearKeyPressDictionary()
        {
            _dicKeyPresses.Clear();
        }

        public void ClearButtonPressDictionary()
        {
            _dicButtonPresses.Clear();
        }

        public bool ContainsPress(CommandType commandType, bool clearPress)
        {
            if (_dicAllCommands.ContainsKey(commandType))
            {
                KeyControl key = _dicAllCommands[commandType].KEY;
                ButtonControl button = _dicAllCommands[commandType].BUTTON;

                if (key != null)
                {
                    if (_dicKeyPresses.ContainsKey(key))
                    {
                        if (clearPress)
                        {
                            _dicKeyPresses.Remove(key);
                        }

                        return true;
                    }
                }
                else if (button != null)
                {
                    if (_dicButtonPresses.ContainsKey(button))
                    {
                        if (clearPress)
                        {
                            _dicButtonPresses.Remove(button);
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        public bool ContainsHold(CommandType commandType)
        {
            if (_dicAllCommands.ContainsKey(commandType))
            {
                KeyControl key = _dicAllCommands[commandType].KEY;
                ButtonControl button = _dicAllCommands[commandType].BUTTON;

                if (key != null)
                {
                    if (_listKeyHolds.Contains(key))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (button != null)
                {
                    if (_listButtonHolds.Contains(button))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        public bool ContainsHoldOrPress(CommandType commandType)
        {
            if (ContainsPress(commandType, false))
            {
                return true;
            }

            if (ContainsHold(commandType))
            {
                return true;
            }

            return false;
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

            if (!keyControl.isPressed || keyControl.wasReleasedThisFrame)
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

            if (!buttonControl.isPressed || buttonControl.wasReleasedThisFrame)
            {
                if (ContainsButtonHold(buttonControl))
                {
                    RemoveButtonHold(buttonControl);
                }
            }
        }

        bool ContainsKeyHold(KeyControl keyControl)
        {
            foreach (KeyControl key in _listKeyHolds)
            {
                if (keyControl == key)
                {
                    return true;
                }
            }

            return false;
        }

        bool ContainsButtonHold(ButtonControl buttonControl)
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

        void RemoveKeyHold(KeyControl keyControl)
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

        void RemoveButtonHold(ButtonControl buttonControl)
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
    }
}