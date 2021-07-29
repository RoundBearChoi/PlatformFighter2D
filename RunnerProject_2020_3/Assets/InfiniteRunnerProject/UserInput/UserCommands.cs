using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class UserCommands
    {
        private Dictionary<CommandType, UserCommand> _dicCommands = new Dictionary<CommandType, UserCommand>();

        public void AddCommand(UserCommand command)
        {
            if (!_dicCommands.ContainsKey(command.COMMAND_TYPE))
            {
                _dicCommands.Add(command.COMMAND_TYPE, command);
            }
            else
            {
                _dicCommands[command.COMMAND_TYPE] = command;
            }
        }

        public bool CommandIsPressed(CommandType commandType)
        {
            if (_dicCommands.ContainsKey(commandType))
            {
                KeyControl key = _dicCommands[commandType].KEY;
                ButtonControl button = _dicCommands[commandType].BUTTON;

                if (key != null)
                {

                }

                if (button != null)
                {

                }
            }
            
            return false;
        }
    }
}