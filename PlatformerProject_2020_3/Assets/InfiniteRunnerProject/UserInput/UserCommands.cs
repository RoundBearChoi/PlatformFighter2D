using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class UserCommands
    {
        private Dictionary<CommandType, UserCommand> _dicAllCommands = new Dictionary<CommandType, UserCommand>();
        private Dictionary<ButtonControl, bool> _dicPresses = new Dictionary<ButtonControl, bool>();

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
                UpdateKeyPress(data.Value.BUTTON);
            }
        }

        public bool ContainsPress(CommandType commandType, bool requireUnusedButton)
        {
            if (_dicAllCommands.ContainsKey(commandType))
            {
                ButtonControl button = _dicAllCommands[commandType].BUTTON;

                if (_dicPresses.ContainsKey(button))
                {
                    if (requireUnusedButton)
                    {
                        if (_dicPresses[button] == false)
                        {
                            _dicPresses[button] = true;
                            return true;
                        }
                    }
                    else
                    {
                        _dicPresses[button] = true;
                        return true;
                    }
                }
            }

            return false;
        }

        void UpdateKeyPress(ButtonControl buttonControl)
        {
            if (buttonControl.wasPressedThisFrame)
            {
                if (!_dicPresses.ContainsKey(buttonControl))
                {
                    _dicPresses.Add(buttonControl, false);
                }
            }

            if (!buttonControl.isPressed || buttonControl.wasReleasedThisFrame)
            {
                if (_dicPresses.ContainsKey(buttonControl))
                {
                    _dicPresses.Remove(buttonControl);
                }
            }
        }

        public void UpdatePressAndHold(bool[] inputArray)
        {
            UpdatePressOnClientInput(CommandType.MOVE_UP, inputArray[0]);
            UpdatePressOnClientInput(CommandType.MOVE_DOWN, inputArray[1]);
            UpdatePressOnClientInput(CommandType.MOVE_LEFT, inputArray[2]);
            UpdatePressOnClientInput(CommandType.MOVE_RIGHT, inputArray[3]);
            UpdatePressOnClientInput(CommandType.JUMP, inputArray[4]);
            UpdatePressOnClientInput(CommandType.ATTACK_A, inputArray[5]);
            UpdatePressOnClientInput(CommandType.SHIFT, inputArray[6]);
        }

        void UpdatePressOnClientInput(CommandType commandType, bool isHeld)
        {
            if (_dicAllCommands.ContainsKey(commandType))
            {
                ButtonControl button = _dicAllCommands[commandType].BUTTON;

                if (isHeld)
                {
                    if (!_dicPresses.ContainsKey(button))
                    {
                        _dicPresses.Add(button, false);
                    }
                }
                else
                {
                    if (_dicPresses.ContainsKey(button))
                    {
                        _dicPresses.Remove(button);
                    }
                }
            }
        }
    }
}