using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LevelLoader : GameResources<int>
    {
        public LevelLoader()
        {
            Debugger.Log("loading levels..");

            LoadObj<GameObject>(1, "Level_1_Temp");
        }
    }
}