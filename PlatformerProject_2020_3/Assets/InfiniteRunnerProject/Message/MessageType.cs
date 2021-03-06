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
        TRIGGER_STOMPEDSTATE = 601,
        ZERO_HEALTH = 610,

        SHOW_LANDING_DUST = 700,
        SHOW_DASH_DUST = 701,
        SHOW_STEP_DUST = 702,
        SHOW_SLIDE_DUST = 703,
        SHOW_JUMP_DUST = 704,
        SHOW_SMASH_DUST = 705,
        SHOW_WALLSLIDE_DUST = 706,
        SHOW_WALLJUMP_DUST = 708,
        SHOW_FALL_DUST = 709,

        HOST_IP_ENTERED = 5000,
        TRANSITION_TO_CONNECTED_STAGE = 5001,
        SHOW_PRIVATE_IP = 5002,
        SHOW_PUBLIC_IP = 5003,

        CLEAR_ONESCAPE_CHILD_ELEMENTS = 6000,
    }
}