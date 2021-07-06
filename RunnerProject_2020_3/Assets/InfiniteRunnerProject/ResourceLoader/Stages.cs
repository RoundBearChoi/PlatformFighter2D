using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Stages : GameResources<StageType>
    {
        public Stages()
        {
            Debugger.Log("loading stages..");

            LoadObj<GameStage>(StageType.GAME_STAGE, "GameStage");
            LoadObj<RunnerStage>(StageType.RUNNER_STAGE, "RunnerStage");
            //LoadObj("IntroStage", typeof(IntroStage));
            //LoadObj("SpritesStage", typeof(SpritesStage));
        }
    }
}