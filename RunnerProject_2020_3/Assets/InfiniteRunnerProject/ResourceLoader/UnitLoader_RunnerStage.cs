using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UnitLoader_RunnerStage : GameResources<UnitType>
    {
        public UnitLoader_RunnerStage()
        {
            Debugger.Log("loading units..");

            LoadObj<PlayerUnit>(UnitType.RUNNER, "Prefab_Runner");
            LoadObj<Golem>(UnitType.GOLEM, "Golem");

            LoadObj<GameObject>(UnitType.FLAT_GROUND, "FlatGround");

            LoadObj<LandingDust>(UnitType.LANDING_DUST, "LandingDust");
            LoadObj<StepDust>(UnitType.STEP_DUST, "StepDust");
            LoadObj<DashDust>(UnitType.DASH_DUST, "DashDust");
            LoadObj<SlideDust>(UnitType.SLIDE_DUST, "SlideDust");
            LoadObj<JumpDust>(UnitType.JUMP_DUST, "JumpDust");
            LoadObj<SmashDust>(UnitType.SMASH_DUST, "SmashDust");

            LoadObj<Blood_5>(UnitType.BLOOD_5, "Blood_5");
            LoadObj<ParryEffect>(UnitType.PARRY_EFFECT, "ParryEffect");

            LoadObj<Swamp>(UnitType.SWAMP, "SwampBackground");
        }
    }
}