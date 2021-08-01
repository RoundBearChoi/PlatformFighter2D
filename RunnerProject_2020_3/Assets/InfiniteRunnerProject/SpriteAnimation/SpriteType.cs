using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public enum SpriteType
    {
        NONE = 0,

        BLOOD_1 = 1,
        BLOOD_2 = 2,
        BLOOD_3 = 3,
        BLOOD_4 = 4,
        BLOOD_5 = 5,

        DUST_DASH = 100,
        DUST_JUMP = 101,
        DUST_LAND = 102,
        DUST_SLIDE = 102,
        DUST_SMASH = 103,
        DUST_STEP = 104,

        GOLEM_ATTACK_A = 200,
        GOLEM_ATTACK_B = 201,

        GOLEM_DEATH = 250,
        GOLEM_IDLE = 251,
        GOLEM_WINCING = 252,

        LITTLE_RED_IDLE = 300,
        LITTLE_RED_RUN = 301,
        LITTLE_RED_WALLSLIDE = 302,

        LITTLE_RED_ATTACK_A = 350,
        LITTLE_RED_ATTACK_B = 351,
        LITTLE_RED_ATTACK_C = 352,

        LITTLE_RED_JUMP_FALL = 360,
        LITTLE_RED_JUMP_UP = 361,

        OLDCITY_PLATFORMS = 400,
        OLDCITY_ARCHES = 401,
        OLDCITY_PILLARS = 402,
        OLDCITY_BOTTOMFOG = 403,
        OLDCITY_TOPFOG = 404,

        HITEFFECT_PARRY = 500,

        RUNNER_ATTACK_A = 600,
        RUNNER_ATTACK_B = 601,
        RUNNER_OVERHEAD = 602,
        RUNNER_SMASH_AIR_FALL = 603,
        RUNNER_SMASH_AIR_LAND = 604,
        RUNNER_SMASH_AIR_PREP = 605,

        RUNNER_ATTACK_A_DASH = 610,

        RUNNER_COMBOTRANSITIONTO_SMASH = 620,

        RUNNER_CROUCH = 650,
        RUNNER_CROUCH_GETUP = 651,
        RUNNER_DEATH = 652,
        RUNNER_IDLE = 653,
        RUNNER_JUMP_UP = 654,
        RUNNER_JUMP_FALL = 655,
        RUNNER_NORMAL_RUN = 656,
        RUNNER_SLIDE = 657,
        RUNNER_SLIDE_GETUP = 658,
        RUNNER_TEMP_DEATH = 659,
        RUNNER_WINCING = 660,

        SWAMP_BACKTREES = 700,
        SWAMP_FRONTTREES = 701,
        SWAMP_GRASS = 702,
        SWAMP_RIVER = 703,
    }
}