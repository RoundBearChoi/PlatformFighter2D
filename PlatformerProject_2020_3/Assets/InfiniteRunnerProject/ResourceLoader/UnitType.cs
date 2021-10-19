using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public enum UnitType
    {
        NONE = 0,

        RUNNER = 100,

        LANDING_DUST = 301,
        STEP_DUST = 302,
        DASH_DUST = 303,
        SLIDE_DUST = 304,
        JUMP_DUST = 305,
        SMASH_DUST = 306,
        WALLSLIDE_DUST = 307,
        WALLJUMP_DUST = 308,
        FALL_DUST = 309,

        OLDCITY_BACKGROUND_TOP_FOG = 402,
        OLDCITY_BACKGROUND_BOTTOM_FOG = 403,
        OLDCITY_BACKGROUND_ARCHES = 404,
        OLDCITY_BACKGROUND_BACKGROUND = 405,
        OLDCITY_BACKGROUND_PILLARS = 406,

        BLOOD_5 = 500,
        DeathFX_Light = 510,
        DeathFX_Dark = 511,

        PARRY_EFFECT = 600,
        UPPERCUT_EFFECT_LIGHT = 601,
        UPPERCUT_EFFECT_DARK = 602,

        LITTLE_RED_LIGHT = 700,
        LITTLE_RED_DARK = 701,
    }
}