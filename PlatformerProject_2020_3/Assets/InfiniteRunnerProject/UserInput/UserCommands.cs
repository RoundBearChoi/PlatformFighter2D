using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class UserCommands
    {
        private Dictionary<CommandType, List<ButtonControl>> _dicAllCommands = new Dictionary<CommandType, List<ButtonControl>>();
        private Dictionary<ButtonControl, bool[]> _dicPresses = new Dictionary<ButtonControl, bool[]>();

        public void AddCommand(CommandType commandType, ButtonControl buttonControl)
        {
            if (!_dicAllCommands.ContainsKey(commandType))
            {
                List<ButtonControl> listControls = new List<ButtonControl>();
                _dicAllCommands.Add(commandType, listControls);
            }

            _dicAllCommands[commandType].Add(buttonControl);
        }

        public void SetPressesDictionary()
        {
            foreach(KeyValuePair<CommandType, List<ButtonControl>> data in _dicAllCommands)
            {
                foreach(ButtonControl button in data.Value)
                {
                    if (!_dicPresses.ContainsKey(button))
                    {
                        _dicPresses.Add(button, new bool[2]);
                    }
                }
            }
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
                        if (_dicPresses[b][0] == true)
                        {
                            if (requireUnusedButton)
                            {
                                if (_dicPresses[b][1] == false)
                                {
                                    _dicPresses[b][1] = true;
                                    return true;
                                }
                            }
                            else
                            {
                                _dicPresses[b][1] = true;
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
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

        public void SetDebug(Unit player)
        {
            GameObject obj = GameObject.Instantiate(Resources.Load("PressesDebug")) as GameObject;
            obj.transform.parent = player.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;

            PressesDebug pressesDebug = obj.GetComponent<PressesDebug>();
            pressesDebug.allCommands = _dicAllCommands;
            pressesDebug.presses = _dicPresses;
        }

        void UpdateKeyPress(ButtonControl buttonControl)
        {
            if (buttonControl.wasPressedThisFrame)
            {
                if (_dicPresses.ContainsKey(buttonControl))
                {
                    _dicPresses[buttonControl][0] = true;
                }
            }

            if (!buttonControl.isPressed || buttonControl.wasReleasedThisFrame)
            {
                if (_dicPresses.ContainsKey(buttonControl))
                {
                    _dicPresses[buttonControl][0] = false;
                    _dicPresses[buttonControl][1] = false;
                }
            }
        }

        void UpdatePressOnClientInput(CommandType commandType, bool isHeld)
        {
            if (_dicAllCommands.ContainsKey(commandType))
            {
                foreach(ButtonControl b in _dicAllCommands[commandType])
                {
                    if (isHeld)
                    {
                        if (_dicPresses.ContainsKey(b))
                        {
                            _dicPresses[b][0] = true;
                        }
                    }
                    else
                    {
                        if (_dicPresses.ContainsKey(b))
                        {
                            _dicPresses[b][0] = false;
                            _dicPresses[b][1] = false;
                        }
                    }
                }
            }
        }
    }
}