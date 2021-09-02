using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UIElementLoader_RunnerStage : GameResources<UIElementType>
    {
        public UIElementLoader_RunnerStage()
        {
            Debugger.Log("loading ui elements..");

            LoadObj<UIElement>(UIElementType.RUNNER_HP_BAR, "RunnerHPBar");
        }
    }
}