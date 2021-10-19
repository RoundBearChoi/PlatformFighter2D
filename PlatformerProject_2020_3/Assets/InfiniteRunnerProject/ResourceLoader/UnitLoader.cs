using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UnitLoader : GameResources<UnitType>
    {
        public UnitLoader()
        {

        }

        public void LoadRunnerStageUnits()
        {
            LoadObj<Runner>(UnitType.RUNNER, "Prefab_Runner");
        }

        public void LoadFightStageUnits()
        {
            LoadObj<LittleRed>(UnitType.LITTLE_RED_LIGHT, "Prefab_LittleRed");
            LoadObj<LittleRed>(UnitType.LITTLE_RED_DARK, "Prefab_LittleRed");
            LoadObj<OldCityBackground>(UnitType.OLD_CITY, "OldCityBackground");
        }

        public void LoadDustEffects()
        {
            LoadObj<LandingDust>(UnitType.LANDING_DUST, "LandingDust");
            LoadObj<WallSlideDust>(UnitType.WALLSLIDE_DUST, "WallSlideDust");
            LoadObj<WallJumpDust>(UnitType.WALLJUMP_DUST, "WallJumpDust");
            LoadObj<StepDust>(UnitType.STEP_DUST, "StepDust");
            LoadObj<DashDust>(UnitType.DASH_DUST, "DashDust");
            LoadObj<SlideDust>(UnitType.SLIDE_DUST, "SlideDust");
            LoadObj<JumpDust>(UnitType.JUMP_DUST, "JumpDust");
            LoadObj<SmashDust>(UnitType.SMASH_DUST, "SmashDust");
            LoadObj<FallDust>(UnitType.FALL_DUST, "FallDust");
        }

        public void LoadHitEffects()
        {
            LoadObj<Blood_5>(UnitType.BLOOD_5, "Blood_5");
            LoadObj<ParryEffect>(UnitType.PARRY_EFFECT, "ParryEffect");

            LoadObj<UppercutEffect_Light>(UnitType.UPPERCUT_EFFECT_LIGHT, "UppercutEffect_Light");
            LoadObj<UppercutEffect_Dark>(UnitType.UPPERCUT_EFFECT_DARK, "UppercutEffect_Dark");

            LoadObj<DeathFX_Light>(UnitType.DeathFX_Light, "DeathFX_Light");
            LoadObj<DeathFX_Dark>(UnitType.DeathFX_Dark, "DeathFX_Dark");
        }
    }
}