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
        private KeyControl _keyControl = null;

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
            _keyControl = null;
        }

        public UserCommand(CommandType commandType, KeyControl key)
        {
            _commandType = commandType;
            _keyControl = key;
            _buttonControl = null;
        }

        public ButtonControl BUTTON
        {
            get
            {
                return _buttonControl;
            }
        }

        public KeyControl KEY
        {
            get
            {
                return _keyControl;
            }
        }
    }
}