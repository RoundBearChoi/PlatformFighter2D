using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RB
{
    [System.Serializable]
    public class UserInput
    {
        public UserCommands commands = new UserCommands();

        private Keyboard _keyboard = null;
        private Mouse _mouse = null;
        private Gamepad _gamepad = null;

        [SerializeField]
        private bool _keyboardDetected = false;

        [SerializeField]
        private bool _mouseDetected = false;

        [SerializeField]
        private bool _gamepadDetected = false;

        public Keyboard KEYBOARD
        {
            get
            {
                return _keyboard;
            }
        }

        public UserInput(Keyboard keyboard, Mouse mouse, Gamepad gamepad)
        {
            _keyboard = keyboard;
            _mouse = mouse;
            _gamepad = gamepad;

            if (_mouse != null)
            {
                _mouseDetected = true;

                commands.AddCommand(CommandType.ATTACK_A, _mouse.leftButton);
                commands.AddCommand(CommandType.ATTACK_B, _mouse.rightButton);
            }

            if (_keyboard != null)
            {
                _keyboardDetected = true;

                commands.AddCommand(CommandType.ATTACK_A, _keyboard.enterKey);
                //commands.AddCommand(CommandType.ATTACK_B, _mouse.rightButton);

                commands.AddCommand(CommandType.MOVE_UP, _keyboard.wKey);
                commands.AddCommand(CommandType.MOVE_DOWN, _keyboard.sKey);
                commands.AddCommand(CommandType.MOVE_LEFT, _keyboard.aKey);
                commands.AddCommand(CommandType.MOVE_RIGHT, _keyboard.dKey);

                commands.AddCommand(CommandType.JUMP, _keyboard.spaceKey);
                commands.AddCommand(CommandType.SHIFT, _keyboard.shiftKey);

                commands.AddCommand(CommandType.F4, _keyboard.f4Key);
                commands.AddCommand(CommandType.F5, _keyboard.f5Key);
                commands.AddCommand(CommandType.F6, _keyboard.f6Key);
                commands.AddCommand(CommandType.F7, _keyboard.f7Key);
                commands.AddCommand(CommandType.F8, _keyboard.f8Key);
                commands.AddCommand(CommandType.F9, _keyboard.f9Key);
                commands.AddCommand(CommandType.F10, _keyboard.f10Key);
                commands.AddCommand(CommandType.F11, _keyboard.f11Key);

                commands.AddCommand(CommandType.ENTER, _keyboard.enterKey);
                commands.AddCommand(CommandType.ARROW_UP, _keyboard.upArrowKey);
                commands.AddCommand(CommandType.ARROW_DOWN, _keyboard.downArrowKey);
                commands.AddCommand(CommandType.ARROW_LEFT, _keyboard.leftArrowKey);
                commands.AddCommand(CommandType.ARROW_RIGHT, _keyboard.rightArrowKey);
                commands.AddCommand(CommandType.ESCAPE, _keyboard.escapeKey);
            }

            if (_gamepad != null)
            {
                _gamepadDetected = true;

                commands.AddCommand(CommandType.ATTACK_A, _gamepad.buttonEast);

                commands.AddCommand(CommandType.MOVE_UP, _gamepad.leftStick.up);
                commands.AddCommand(CommandType.MOVE_DOWN, _gamepad.leftStick.down);
                commands.AddCommand(CommandType.MOVE_LEFT, _gamepad.leftStick.left);
                commands.AddCommand(CommandType.MOVE_RIGHT, _gamepad.leftStick.right);

                commands.AddCommand(CommandType.MOVE_UP, _gamepad.dpad.up);
                commands.AddCommand(CommandType.MOVE_DOWN, _gamepad.dpad.down);
                commands.AddCommand(CommandType.MOVE_LEFT, _gamepad.dpad.left);
                commands.AddCommand(CommandType.MOVE_RIGHT, _gamepad.dpad.right);

                commands.AddCommand(CommandType.JUMP, _gamepad.buttonSouth);
                commands.AddCommand(CommandType.SHIFT, _gamepad.buttonWest);
            }
        }

        public void OnUpdate()
        {
            commands.OnUpdate();
        }
    }
}