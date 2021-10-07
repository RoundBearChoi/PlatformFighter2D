using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace RB
{
    [System.Serializable]
    public class UserInput
    {
        [SerializeField]
        InputType _inputType = InputType.NONE;

        public Gamepad gamepad = null;

        public UserCommands commands = new UserCommands();

        public InputType INPUT_TYPE
        {
            get
            {
                return _inputType;
            }
        }

        public UserInput(InputType inputType)
        {
            _inputType = inputType;

            //keyboard = Keyboard.current;
            //mouse = Mouse.current;

            try
            {
                if (Mouse.current != null)
                {
                    commands.AddCommand(new UserCommand(CommandType.ATTACK_A, Mouse.current.leftButton));
                    commands.AddCommand(new UserCommand(CommandType.ATTACK_B, Mouse.current.rightButton));
                }

                if (Keyboard.current != null)
                {
                    commands.AddCommand(new UserCommand(CommandType.MOVE_UP, Keyboard.current.wKey));
                    commands.AddCommand(new UserCommand(CommandType.MOVE_DOWN, Keyboard.current.sKey));
                    commands.AddCommand(new UserCommand(CommandType.MOVE_LEFT, Keyboard.current.aKey));
                    commands.AddCommand(new UserCommand(CommandType.MOVE_RIGHT, Keyboard.current.dKey));

                    commands.AddCommand(new UserCommand(CommandType.JUMP, Keyboard.current.spaceKey));

                    commands.AddCommand(new UserCommand(CommandType.SHIFT, Keyboard.current.shiftKey));

                    commands.AddCommand(new UserCommand(CommandType.F4, Keyboard.current.f4Key));
                    commands.AddCommand(new UserCommand(CommandType.F5, Keyboard.current.f5Key));
                    commands.AddCommand(new UserCommand(CommandType.F6, Keyboard.current.f6Key));
                    commands.AddCommand(new UserCommand(CommandType.F7, Keyboard.current.f7Key));
                    commands.AddCommand(new UserCommand(CommandType.F8, Keyboard.current.f8Key));
                    commands.AddCommand(new UserCommand(CommandType.F9, Keyboard.current.f9Key));
                    commands.AddCommand(new UserCommand(CommandType.F10, Keyboard.current.f10Key));
                    commands.AddCommand(new UserCommand(CommandType.F11, Keyboard.current.f11Key));

                    commands.AddCommand(new UserCommand(CommandType.ENTER, Keyboard.current.enterKey));
                    commands.AddCommand(new UserCommand(CommandType.ARROW_UP, Keyboard.current.upArrowKey));
                    commands.AddCommand(new UserCommand(CommandType.ARROW_DOWN, Keyboard.current.downArrowKey));
                    commands.AddCommand(new UserCommand(CommandType.ARROW_LEFT, Keyboard.current.leftArrowKey));
                    commands.AddCommand(new UserCommand(CommandType.ARROW_RIGHT, Keyboard.current.rightArrowKey));
                    commands.AddCommand(new UserCommand(CommandType.ESCAPE, Keyboard.current.escapeKey));
                }
            }
            catch (System.Exception e)
            {
                Debugger.Log(e);
            }
        }

        public void InitGamepadInput()
        {
            commands.AddCommand(new UserCommand(CommandType.ATTACK_A, gamepad.buttonEast));

            commands.AddCommand(new UserCommand(CommandType.MOVE_UP, gamepad.leftStick.up));
            commands.AddCommand(new UserCommand(CommandType.MOVE_DOWN, gamepad.leftStick.down));
            commands.AddCommand(new UserCommand(CommandType.MOVE_LEFT, gamepad.leftStick.left));
            commands.AddCommand(new UserCommand(CommandType.MOVE_RIGHT, gamepad.leftStick.right));

            //commands.AddCommand(new UserCommand(CommandType.MOVE_UP, gamepad.dpad.up));
            //commands.AddCommand(new UserCommand(CommandType.MOVE_DOWN, gamepad.dpad.down));
            //commands.AddCommand(new UserCommand(CommandType.MOVE_LEFT, gamepad.dpad.left));
            //commands.AddCommand(new UserCommand(CommandType.MOVE_RIGHT, gamepad.dpad.right));

            commands.AddCommand(new UserCommand(CommandType.JUMP, gamepad.buttonSouth));

            commands.AddCommand(new UserCommand(CommandType.SHIFT, gamepad.buttonWest));
        }

        public void OnUpdate()
        {
            commands.OnUpdate();
        }
    }
}