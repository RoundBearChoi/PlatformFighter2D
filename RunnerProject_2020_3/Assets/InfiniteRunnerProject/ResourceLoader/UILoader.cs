using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UILoader : GameResources<UIType>
    {
        public UILoader()
        {
            Debugger.Log("loading ui..");

            LoadObj<GameUI>(UIType.GAME_UI, "GameUI");
            LoadObj<BasicInfoLayer>(UIType.BASIC_INFO_LAYER, "BasicInfoLayer");

            LoadObj<UITest.tempUI>(UIType.UI, "tempUI");
            LoadObj<UITest.DefaultUIBlock>(UIType.DEFAULT_UI_BLOCK, "DefaultUIBlock");
            LoadObj<UITest.RunnerDeathNotification>(UIType.RUNNER_DEATH_NOTIFICATION, "RunnerDeathNotification");
        }
    }
}