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

            LoadObj<IntroCamera>(etcType.INTRO_CAMERA, "IntroCamera");
            LoadObj<GameCamera>(etcType.GAME_CAMERA, "GameCamera");
            LoadObj<FightCamera>(etcType.FIGHT_CAMERA, "FightCamera");
        }
    }
}