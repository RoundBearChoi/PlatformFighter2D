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

        SHOW_BLOOD_5 = 400,
        SHOW_PARRY_EFFECT = 401,

        SHAKE_CAMERA_ONTARGET = 500,
        SHAKE_CAMERA_ONPOSITION = 501,

        TAKE_DAMAGE = 600,
        ZERO_HEALTH = 610,

        SHOW_LANDING_DUST = 700,
        SHOW_DASH_DUST = 701,
        SHOW_STEP_DUST = 702,
        SHOW_SLIDE_DUST = 703,
        SHOW_JUMP_DUST = 704,
        SHOW_SMASH_DUST = 705,
    }
}