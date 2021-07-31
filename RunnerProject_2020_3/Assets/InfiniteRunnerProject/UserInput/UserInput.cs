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

        public static Keyboard keyboard = null;
        public static Mouse mouse = null;

        public UserCommands commands = new UserCommands();

        public UserInput(InputType inputType)
        {
            _inputType = inputType;

            keyboard = Keyboard.current;
            mouse = Mouse.current;

            try
            {
                if (mouse != null)
                {
                    commands.AddCommand(new UserCommand(CommandType.ATTACK_A, mouse.leftButton));
                    commands.AddCommand(new UserCommand(CommandType.ATTACK_B, mouse.rightButton));
                }

                if (keyboard != null)
                {
                    commands.AddCommand(new UserCommand(CommandType.MOVE_UP, keyboard.wKey));
                    commands.AddCommand(new UserCommand(CommandType.MOVE_DOWN, keyboard.sKey));
                    commands.AddCommand(new UserCommand(CommandType.MOVE_LEFT, keyboard.aKey));
                    commands.AddCommand(new UserCommand(CommandType.MOVE_RIGHT, keyboard.dKey));

                    commands.AddCommand(new UserCommand(CommandType.JUMP, keyboard.spaceKey));

                    commands.AddCommand(new UserCommand(CommandType.F4, keyboard.f4Key));
                    commands.AddCommand(new UserCommand(CommandType.F5, keyboard.f5Key));
                    commands.AddCommand(new UserCommand(CommandType.F6, keyboard.f6Key));
                    commands.AddCommand(new UserCommand(CommandType.F7, keyboard.f7Key));
                    commands.AddCommand(new UserCommand(CommandType.F8, keyboard.f8Key));
                    commands.AddCommand(new UserCommand(CommandType.F9, keyboard.f9Key));
                    commands.AddCommand(new UserCommand(CommandType.F10, keyboard.f10Key));
                    commands.AddCommand(new UserCommand(CommandType.F11, keyboard.f11Key));
                }
            }
            catch (System.Exception e)
            {
                Debugger.Log(e);
            }
        }

        public void OnUpdate()
        {
            commands.OnUpdate();
        }
    }
}