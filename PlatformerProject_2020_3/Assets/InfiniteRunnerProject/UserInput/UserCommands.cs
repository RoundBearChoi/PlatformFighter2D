using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class UserCommands
    {
        private Dictionary<CommandType, UserCommand> _dicAllCommands = new Dictionary<CommandType, UserCommand>();
        private List<ButtonControl> _listButtonPresses = new List<ButtonControl>();

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

        public bool ContainsPress(CommandType commandType, bool clearPress)
        {
            if (_dicAllCommands.ContainsKey(commandType))
            {
                if (_listButtonPresses.Contains(_dicAllCommands[commandType].BUTTON))
                {
                    if (clearPress)
                    {
                        _listButtonPresses.Remove(_dicAllCommands[commandType].BUTTON);
                    }

                    return true;
                }
            }

            return false;
        }

        void UpdateKeyPress(ButtonControl buttonControl)
        {
            if (buttonControl.wasPressedThisFrame)
            {
                if (!_listButtonPresses.Contains(buttonControl))
                {
                    _listButtonPresses.Add(buttonControl);
                }
            }

            if (!buttonControl.isPressed || buttonControl.wasReleasedThisFrame)
            {
                if (_listButtonPresses.Contains(buttonControl))
                {
                    _listButtonPresses.Remove(buttonControl);
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
                if (isHeld)
                {
                    if (!_listButtonPresses.Contains(_dicAllCommands[commandType].BUTTON))
                    {
                        _listButtonPresses.Add(_dicAllCommands[commandType].BUTTON);
                    }
                }
                else
                {
                    if (_listButtonPresses.Contains(_dicAllCommands[commandType].BUTTON))
                    {
                        _listButtonPresses.Remove(_dicAllCommands[commandType].BUTTON);
                    }
                }
            }
        }
    }
}