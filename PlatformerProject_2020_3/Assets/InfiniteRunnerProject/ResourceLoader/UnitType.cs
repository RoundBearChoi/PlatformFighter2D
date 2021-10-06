using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public enum UnitType
    {
        NONE = 0,

        RUNNER = 100,
        GOLEM = 101,

        FLAT_GROUND = 200,

        LANDING_DUST = 301,
        STEP_DUST = 302,
        DASH_DUST = 303,
        SLIDE_DUST = 304,
        JUMP_DUST = 305,
        SMASH_DUST = 306,
        WALLSLIDE_DUST = 307,
        WALLJUMP_DUST = 308,

        SWAMP = 400,
        OLD_CITY = 401,

        BLOOD_5 = 500,
        DeathFX_Light = 510,
        DeathFX_Dark = 511,

        PARRY_EFFECT = 600,
        UPPERCUT_EFFECT_LIGHT = 601,

        LITTLE_RED_LIGHT = 700,
        LITTLE_RED_DARK = 701,
    }
}