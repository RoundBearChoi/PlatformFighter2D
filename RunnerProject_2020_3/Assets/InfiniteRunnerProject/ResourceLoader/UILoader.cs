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

            LoadObj<UI>(UIType.UI, "UI");
            LoadObj<DefaultUIBlock>(UIType.DEFAULT_UI_BLOCK, "DefaultUIBlock");
            LoadObj<RunnerDeathNotification>(UIType.RUNNER_DEATH_NOTIFICATION, "RunnerDeathNotification");
        }
    }
}