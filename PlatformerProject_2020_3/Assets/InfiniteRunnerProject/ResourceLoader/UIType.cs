using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public enum UIType
    {
        COMPATIBLE_BASE_UI,
        COMPATIBLE_UI_LAYER,

        //should have separate ui selection types
        INTRO_SELECT,
        HOST_GAME_SELECT,
        ON_ESC_SELECT,

        SELECTION_ARROW,
        CONNECTED_UI,

        //temp
        UI,
        DEFAULT_UI_BLOCK,
        RUNNER_DEATH_NOTIFICATION,
    }
}