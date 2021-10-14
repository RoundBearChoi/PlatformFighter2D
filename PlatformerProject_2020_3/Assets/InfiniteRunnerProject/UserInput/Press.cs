using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    [System.Serializable]
    public class Press
    {
        ButtonControl _buttonControl = null;

        [SerializeField]
        CommandType _commandType = CommandType.NONE;

        [SerializeField]
        bool _pressed = false;

        [SerializeField]
        bool _used = false;

        public Press(CommandType commandType, ButtonControl button)
        {
            _commandType = commandType;
            _buttonControl = button;
        }

        public ButtonControl BUTTON_CONTROL
        {
            get
            {
                return _buttonControl;
            }
        }

        public bool PRESSED
        {
            get
            {
                return _pressed;
            }
        }

        public bool USED
        {
            get
            {
                return _used;
            }
        }

        public void SetPressed(bool pressed)
        {
            _pressed = pressed;
        }

        public void SetUsed(bool used)
        {
            _used = used;
        }
    }
}