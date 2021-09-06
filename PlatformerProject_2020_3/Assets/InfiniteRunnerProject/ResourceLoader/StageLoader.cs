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

            LoadObj<IntroStage>(StageType.INTRO_STAGE, "IntroStage");
            LoadObj<TestStage>(StageType.TEST_STAGE, "TestStage");
            LoadObj<RunnerStage>(StageType.RUNNER_STAGE, "RunnerStage");
            LoadObj<FightStage>(StageType.FIGHT_STAGE, "FightStage");
            LoadObj<SpriteStage>(StageType.SPRITE_STAGE, "SpriteStage");

            LoadObj<HostGameStage>(StageType.HOST_GAME_STAGE, "HostGameStage");
            LoadObj<EnterHostIPStage>(StageType.ENTER_IP_STAGE, "EnterHostIPStage");
        }
    }
}