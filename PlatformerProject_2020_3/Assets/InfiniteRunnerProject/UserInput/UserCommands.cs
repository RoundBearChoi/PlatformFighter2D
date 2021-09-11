using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class UserCommands
    {
        private Dictionary<CommandType, UserCommand> _dicAllCommands = new Dictionary<CommandType, UserCommand>();

        private Dictionary<ButtonControl, int> _dicButtonPresses = new Dictionary<ButtonControl, int>();
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
                ButtonControl button = data.Value.BUTTON;

                if (button != null)
                {
                    UpdateKeyPress(button);
                }
            }
        }

        public void ClearKeyPressDictionary()
        {
            _dicButtonPresses.Clear();
        }

        public bool ContainsPress(CommandType commandType, bool clearPress)
        {
            if (_dicAllCommands.ContainsKey(commandType))
            {
                ButtonControl button = _dicAllCommands[commandType].BUTTON;

                if (button != null)
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
                ButtonControl button = _dicAllCommands[commandType].BUTTON;

                if (button != null)
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

        void UpdateKeyPress(ButtonControl buttonControl)
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

                if (!ContainsKeyHold(buttonControl))
                {
                    _listButtonHolds.Add(buttonControl);
                }
            }

            if (!buttonControl.isPressed || buttonControl.wasReleasedThisFrame)
            {
                if (ContainsKeyHold(buttonControl))
                {
                    RemoveKeyHold(buttonControl);
                }
            }
        }

        bool ContainsKeyHold(ButtonControl buttonControl)
        {
            foreach (ButtonControl b in _listButtonHolds)
            {
                if (buttonControl == b)
                {
                    return true;
                }
            }

            return false;
        }

        void RemoveKeyHold(ButtonControl buttonControl)
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

        public void UpdateOnClientInput(bool[] inputArray)
        {
            UpdateCommandOnClientInputData(CommandType.MOVE_UP, inputArray[0]);
            UpdateCommandOnClientInputData(CommandType.MOVE_DOWN, inputArray[1]);
            UpdateCommandOnClientInputData(CommandType.MOVE_LEFT, inputArray[2]);
            UpdateCommandOnClientInputData(CommandType.MOVE_RIGHT, inputArray[3]);
            UpdateCommandOnClientInputData(CommandType.JUMP, inputArray[4]);
            UpdateCommandOnClientInputData(CommandType.ATTACK_A, inputArray[5]);
        }

        void UpdateCommandOnClientInputData(CommandType commandType, bool isHeld)
        {
            if (_dicAllCommands.ContainsKey(commandType))
            {
                ButtonControl buttonControl = _dicAllCommands[commandType].BUTTON;

                if (isHeld)
                {
                    if (buttonControl != null)
                    {
                        if (!_listButtonHolds.Contains(buttonControl))
                        {
                            _listButtonHolds.Add(buttonControl);
                        }
                    }
                }
                else
                {
                    if (buttonControl != null)
                    {
                        if (_listButtonHolds.Contains(buttonControl))
                        {
                            _listButtonHolds.Remove(buttonControl);
                        }
                    }
                }
            }
        }
    }
}