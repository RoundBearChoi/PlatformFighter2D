using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UnitLoader : GameResources<UnitType>
    {
        public UnitLoader()
        {
            Debugger.Log("loading units..");

            LoadObj<Runner>(UnitType.RUNNER, "Prefab_Runner");
            LoadObj<SampleLeftEnemy>(UnitType.SAMPLE_LEFT_ENEMY, "SampleFrontEnemy");

            LoadObj<Ground>(UnitType.FLAT_GROUND, "FlatGround");

            LoadObj<LandingDust>(UnitType.LANDING_DUST, "LandingDust");
            LoadObj<StepDust>(UnitType.STEP_DUST, "StepDust");

            LoadObj<Swamp>(UnitType.SWAMP_BACKGROUND, "SwampBackground");
            //LoadObj<Swamp>(UnitType.SWAMP_RIVER, "SwampBackground");
        }
    }
}