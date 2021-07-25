using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class etcLoader : GameResources<etcType>
    {
        public etcLoader()
        {
            Debugger.Log("loading other stuff..");

            LoadObj<GameCamera>(etcType.GAME_CAMERA, "GameCamera");
            LoadObj<EnemyHPBar>(etcType.HP_BAR, "EnemyHPBar");
        }
    }
}