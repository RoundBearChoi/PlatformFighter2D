using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class SwampSetup
    {
        public void InstantiateBaseLayer(UserInput userInput)
        {
            Stage.currentStage.InstantiateUnits_ByUnitType(UnitType.SWAMP, userInput);
        }
    }
}