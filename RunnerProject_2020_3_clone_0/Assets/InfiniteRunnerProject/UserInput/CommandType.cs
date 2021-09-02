using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public enum CommandType
    {
        NONE = 0,
        
        MOVE_UP = 100,
        MOVE_DOWN = 101,
        MOVE_LEFT = 102,
        MOVE_RIGHT = 103,

        ATTACK_A = 200,
        ATTACK_B = 201,
        ATTACK_C = 202,

        JUMP = 300,

        SHIFT = 400,

        F4 = 1000,
        F5 = 1001,
        F6 = 1002,
        F7 = 1003,
        F8 = 1004,
        F9 = 1005,
        F10 = 1006,
        F11 = 1007,
    }
}