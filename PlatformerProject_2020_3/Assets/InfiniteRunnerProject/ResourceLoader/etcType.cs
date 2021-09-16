using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public enum etcType
    {
        NONE = 0,

        INTRO_CAMERA,
        GAME_CAMERA,
        FIGHT_CAMERA,

        HP_BAR,

        SERVER_MANAGER,
        CLIENT_MANAGER,

        CLIENT_CONTROLLER,
        CLIENT_INPUT_SENDER,

        CONNECTED_PLAYER_INFO,

        CLIENT_OBJECT,
    }
}