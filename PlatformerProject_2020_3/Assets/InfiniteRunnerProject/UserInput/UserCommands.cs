using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    [System.Serializable]
    public class UserCommands
    {
        private Dictionary<CommandType, List<ButtonControl>> _dicAllCommands = new Dictionary<CommandType, List<ButtonControl>>();

        [SerializeField]
        Presses _presses = new Presses();

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
                    _presses.Add(data.Key, button);
                }
            }
        }

        public void UpdateKeyPresses()
        {
            foreach(KeyValuePair<CommandType, List<ButtonControl>> data in _dicAllCommands)
            {
                foreach(ButtonControl button in data.Value)
                {
                    UpdateKeyPress(button);
                }
            }
        }

        public bool MovementKey_Left()
        {
            if (ContainsPress(CommandType.MOVE_LEFT, false) == true && ContainsPress(CommandType.MOVE_RIGHT, false) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MovementKey_Right()
        {
            if (ContainsPress(CommandType.MOVE_LEFT, false) == false && ContainsPress(CommandType.MOVE_RIGHT, false) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContainsPress(CommandType commandType, bool requireUnusedButton)
        {
            if (_dicAllCommands.ContainsKey(commandType))
            {
                foreach(ButtonControl b in _dicAllCommands[commandType])
                {
                    Press p = _presses.GetPress(b);
                    
                    if (p != null)
                    {
                        if (p.PRESSED)
                        {
                            if (requireUnusedButton)
                            {
                                if (!p.USED)
                                {
                                    p.SetUsed(true);
                                    return true;
                                }
                            }
                            else
                            {
                                p.SetUsed(true);
                                return true;
                            }
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
                Press p = _presses.GetPress(buttonControl);

                if (p != null)
                {
                    p.SetPressed(true);
                }
            }

            if (!buttonControl.isPressed || buttonControl.wasReleasedThisFrame)
            {
                Press p = _presses.GetPress(buttonControl);

                if (p != null)
                {
                    p.SetPressed(false);
                    p.SetUsed(false);
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
                    foreach (ButtonControl b in _dicAllCommands[commandType])
                    {
                        Press p = _presses.GetPress(b);

                        if (p != null)
                        {
                            p.SetPressed(true);
                            break;
                        }
                    }
                }
                else
                {
                    foreach (ButtonControl b in _dicAllCommands[commandType])
                    {
                        Press p = _presses.GetPress(b);

                        if (p != null)
                        {
                            p.SetPressed(false);
                            p.SetUsed(false);
                        }
                    }
                }
            }
        }
    }
}