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
            LoadObj<Golem>(UnitType.GOLEM, "Golem");

            LoadObj<GameObject>(UnitType.FLAT_GROUND, "FlatGround");

            LoadObj<LandingDust>(UnitType.LANDING_DUST, "LandingDust");
            LoadObj<StepDust>(UnitType.STEP_DUST, "StepDust");

            LoadObj<Swamp>(UnitType.SWAMP, "SwampBackground");
        }
    }
}