using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UIElementLoader : GameResources<UIElementType>
    {
        public UIElementLoader()
        {
            Debugger.Log("loading ui elements..");

            LoadObj<UIElement>(UIElementType.RUNNER_HP_BAR, "RunnerHPBar");
            LoadObj<WaitingForPlayers>(UIElementType.WAITING_FOR_PLAYERS, "WaitingForPlayers");
        }
    }
}