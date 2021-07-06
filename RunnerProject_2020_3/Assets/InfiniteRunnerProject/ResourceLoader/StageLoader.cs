using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StageLoader : GameResources<StageType>
    {
        public StageLoader()
        {
            Debugger.Log("loading stages..");

            LoadObj<GameStage>(StageType.GAME_STAGE, "GameStage");
            LoadObj<RunnerStage>(StageType.RUNNER_STAGE, "RunnerStage");
            LoadObj<IntroStage>(StageType.INTRO_STAGE, "IntroStage");
            LoadObj<SpritesStage>(StageType.SPRITE_STAGE, "SpritesStage");
        }
    }
}