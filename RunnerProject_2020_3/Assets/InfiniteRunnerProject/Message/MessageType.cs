using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public enum MessageType
    {
        NONE,

        RUNNER_IS_DEAD = 100,
        UPDATE_RUNNER_HP_UI = 101,

        HITSTOP_REGISTER = 200,

        WINCE = 300,

        SHOW_BLOOD = 400,
        SHOW_PARRY_EFFECT = 401,

        SHAKE_CAMERA = 500,

        TAKE_DAMAGE = 600,
        ZERO_HEALTH = 610,

        SHOW_LANDING_DUST = 700,
    }
}