using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RB
{
    [System.Serializable]
    public class UserInput
    {
        [SerializeField]
        InputType _inputType = InputType.NONE;

        private Keyboard _keyboard = null;
        private Mouse _mouse = null;
        private Gamepad _gamepad = null;

        public UserCommands commands = new UserCommands();

        public InputType INPUT_TYPE
        {
            get
            {
                return _inputType;
            }
        }

        public UserInput(InputType inputType, Keyboard keyboard, Mouse mouse, Gamepad gamepad)
        {
            _inputType = inputType;
            _keyboard = keyboard;
            _mouse = mouse;
            _gamepad = gamepad;

            if (_mouse != null)
            {
                commands.AddCommand(new UserCommand(CommandType.ATTACK_A, _mouse.leftButton));
                commands.AddCommand(new UserCommand(CommandType.ATTACK_B, _mouse.rightButton));
            }

            if (_keyboard != null)
            {
                commands.AddCommand(new UserCommand(CommandType.MOVE_UP, _keyboard.wKey));
                commands.AddCommand(new UserCommand(CommandType.MOVE_DOWN, _keyboard.sKey));
                commands.AddCommand(new UserCommand(CommandType.MOVE_LEFT, _keyboard.aKey));
                commands.AddCommand(new UserCommand(CommandType.MOVE_RIGHT, _keyboard.dKey));

                commands.AddCommand(new UserCommand(CommandType.JUMP, _keyboard.spaceKey));
                commands.AddCommand(new UserCommand(CommandType.SHIFT, _keyboard.shiftKey));

                commands.AddCommand(new UserCommand(CommandType.F4, _keyboard.f4Key));
                commands.AddCommand(new UserCommand(CommandType.F5, _keyboard.f5Key));
                commands.AddCommand(new UserCommand(CommandType.F6, _keyboard.f6Key));
                commands.AddCommand(new UserCommand(CommandType.F7, _keyboard.f7Key));
                commands.AddCommand(new UserCommand(CommandType.F8, _keyboard.f8Key));
                commands.AddCommand(new UserCommand(CommandType.F9, _keyboard.f9Key));
                commands.AddCommand(new UserCommand(CommandType.F10, _keyboard.f10Key));
                commands.AddCommand(new UserCommand(CommandType.F11, _keyboard.f11Key));

                commands.AddCommand(new UserCommand(CommandType.ENTER, _keyboard.enterKey));
                commands.AddCommand(new UserCommand(CommandType.ARROW_UP, _keyboard.upArrowKey));
                commands.AddCommand(new UserCommand(CommandType.ARROW_DOWN, _keyboard.downArrowKey));
                commands.AddCommand(new UserCommand(CommandType.ARROW_LEFT, _keyboard.leftArrowKey));
                commands.AddCommand(new UserCommand(CommandType.ARROW_RIGHT, _keyboard.rightArrowKey));
                commands.AddCommand(new UserCommand(CommandType.ESCAPE, _keyboard.escapeKey));
            }
        }

        public void InitGamepadInput()
        {
            commands.AddCommand(new UserCommand(CommandType.ATTACK_A, _gamepad.buttonEast));

            commands.AddCommand(new UserCommand(CommandType.MOVE_UP, _gamepad.leftStick.up));
            commands.AddCommand(new UserCommand(CommandType.MOVE_DOWN, _gamepad.leftStick.down));
            commands.AddCommand(new UserCommand(CommandType.MOVE_LEFT, _gamepad.leftStick.left));
            commands.AddCommand(new UserCommand(CommandType.MOVE_RIGHT, _gamepad.leftStick.right));

            //commands.AddCommand(new UserCommand(CommandType.MOVE_UP, gamepad.dpad.up));
            //commands.AddCommand(new UserCommand(CommandType.MOVE_DOWN, gamepad.dpad.down));
            //commands.AddCommand(new UserCommand(CommandType.MOVE_LEFT, gamepad.dpad.left));
            //commands.AddCommand(new UserCommand(CommandType.MOVE_RIGHT, gamepad.dpad.right));

            commands.AddCommand(new UserCommand(CommandType.JUMP, _gamepad.buttonSouth));
            commands.AddCommand(new UserCommand(CommandType.SHIFT, _gamepad.buttonWest));
        }

        public void OnUpdate()
        {
            commands.OnUpdate();
        }
    }
}