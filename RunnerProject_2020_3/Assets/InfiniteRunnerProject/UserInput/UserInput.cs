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
        [SerializeField] private UserInputType _userInputType = UserInputType.NONE;
        public static Keyboard keyboard = null;
        public static Mouse mouse = null;

        public UserCommands userCommands = null;

        public UserInput()
        {
            keyboard = Keyboard.current;
            mouse = Mouse.current;

            UserCommand attackA = new UserCommand(CommandType.ATTACK_A, mouse.leftButton);
            UserCommand attackB = new UserCommand(CommandType.ATTACK_B, mouse.rightButton);
            UserCommand up = new UserCommand(CommandType.MOVE_UP, keyboard.wKey);
            UserCommand down = new UserCommand(CommandType.MOVE_DOWN, keyboard.sKey);
            UserCommand jump = new UserCommand(CommandType.JUMP, keyboard.spaceKey);

            UserCommand f4 = new UserCommand(CommandType.F4, keyboard.f4Key);
            UserCommand f5 = new UserCommand(CommandType.F5, keyboard.f5Key);
            UserCommand f6 = new UserCommand(CommandType.F6, keyboard.f6Key);
            UserCommand f7 = new UserCommand(CommandType.F7, keyboard.f7Key);
            UserCommand f8 = new UserCommand(CommandType.F8, keyboard.f8Key);
            UserCommand f10 = new UserCommand(CommandType.F8, keyboard.f10Key);

            userCommands = new UserCommands();
            userCommands.AddCommand(attackA);
            userCommands.AddCommand(attackB);
            userCommands.AddCommand(up);
            userCommands.AddCommand(down);
            userCommands.AddCommand(jump);
            userCommands.AddCommand(f4);
            userCommands.AddCommand(f5);
            userCommands.AddCommand(f6);
            userCommands.AddCommand(f7);
            userCommands.AddCommand(f8);
            userCommands.AddCommand(f10);
        }

        public void OnUpdate()
        {
            userCommands.OnUpdate();
        }
    }
}