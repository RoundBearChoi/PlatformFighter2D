using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    public class UserCommand
    {
        private CommandType _commandType = CommandType.NONE;
        private ButtonControl _buttonControl = null;

        public CommandType COMMAND_TYPE
        {
            get
            {
                return _commandType;
            }
        }

        public UserCommand(CommandType commandType, ButtonControl button)
        {
            _commandType = commandType;
            _buttonControl = button;
        }

        public ButtonControl BUTTON
        {
            get
            {
                return _buttonControl;
            }
        }
    }
}