using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UILoader_RunnerStage : GameResources<UIType>
    {
        public UILoader_RunnerStage()
        {
            Debugger.Log("loading ui..");

            LoadObj<RunnerGameUI>(UIType.RUNNER_GAME_UI, "RunnerGameUI");
            LoadObj<RunnerInfoLayer>(UIType.RUNNER_INFO_LAYER, "RunnerInfoLayer");

            LoadObj<UITest.tempUI>(UIType.UI, "tempUI");
            LoadObj<UITest.DefaultUIBlock>(UIType.DEFAULT_UI_BLOCK, "DefaultUIBlock");
            LoadObj<UITest.RunnerDeathNotification>(UIType.RUNNER_DEATH_NOTIFICATION, "RunnerDeathNotification");

            LoadObj<FighterIntroUI>(UIType.FIGHTER_INTRO_UI, "FighterIntroUI");
            LoadObj<IntroSelectionLayer>(UIType.INTRO_SELECTION_LAYER, "IntroSelectionLayer");
        }
    }
}