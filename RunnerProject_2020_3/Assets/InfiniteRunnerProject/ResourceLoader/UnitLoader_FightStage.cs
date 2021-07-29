using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UnitLoader_FightStage : GameResources<UnitType>
    {
        public UnitLoader_FightStage()
        {
            Debugger.Log("loading units for FightStage..");

            LoadObj<PlayerUnit>(UnitType.LITTLERED_RED, "Prefab_LittleRed_Red");
        }
    }
}