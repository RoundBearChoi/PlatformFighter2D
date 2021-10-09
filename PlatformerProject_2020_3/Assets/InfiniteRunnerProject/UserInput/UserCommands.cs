using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class UserCommands
    {
        private Dictionary<CommandType, List<ButtonControl>> _dicAllCommands = new Dictionary<CommandType, List<ButtonControl>>();
        private Dictionary<ButtonControl, bool> _dicPresses = new Dictionary<ButtonControl, bool>();

        public void AddCommand(CommandType commandType, ButtonControl buttonControl)
        {
            if (!_dicAllCommands.ContainsKey(commandType))
            {
                List<ButtonControl> listControls = new List<ButtonControl>();
                _dicAllCommands.Add(commandType, listControls);
            }

            _dicAllCommands[commandType].Add(buttonControl);
        }

        public void OnUpdate()
        {
            foreach(KeyValuePair<CommandType, List<ButtonControl>> data in _dicAllCommands)
            {
                foreach(ButtonControl button in data.Value)
                {
                    UpdateKeyPress(button);
                }
            }
        }

        public bool ContainsPress(CommandType commandType, bool requireUnusedButton)
        {
            if (_dicAllCommands.ContainsKey(commandType))
            {
                foreach(ButtonControl b in _dicAllCommands[commandType])
                {
                    if (_dicPresses.ContainsKey(b))
                    {
                        if (requireUnusedButton)
                        {
                            if (_dicPresses[b] == false)
                            {
                                _dicPresses[b] = true;
                                return true;
                            }
                        }
                        else
                        {
                            _dicPresses[b] = true;
                            return true;
                        }
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
                foreach(ButtonControl b in _dicAllCommands[commandType])
                {
                    if (isHeld)
                    {
                        if (!_dicPresses.ContainsKey(b))
                        {
                            _dicPresses.Add(b, false);
                        }
                    }
                    else
                    {
                        if (_dicPresses.ContainsKey(b))
                        {
                            _dicPresses.Remove(b);
                        }
                    }
                }
            }
        }
    }
}