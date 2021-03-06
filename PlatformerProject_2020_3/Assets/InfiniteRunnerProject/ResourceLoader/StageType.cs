using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public enum StageType
    {
        TEST_STAGE = 0,
        //RUNNER_STAGE = 1,
        INTRO_STAGE = 2,
        SPRITE_STAGE = 3,

        INPUT_DEVICES_STAGE = 99,
        FIGHT_STAGE = 100,
        MULTIPLAYER_SERVER_STAGE = 101,
        MULTIPLAYER_CLIENT_STAGE = 102,

        MODEL_FIGHT_STAGE = 150,

        HOST_GAME_STAGE = 500,
        ENTER_IP_STAGE = 501,
        CONNECTING_STAGE = 502,
        CONNECTED_STAGE = 503,
    }
}