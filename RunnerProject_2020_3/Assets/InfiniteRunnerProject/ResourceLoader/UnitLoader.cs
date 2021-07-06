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
        }
    }
}