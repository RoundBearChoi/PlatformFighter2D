using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class BasicInfoLayer : UILayer
    {
        public override void InitLayer()
        {
            Debugger.Log("starting basicInfoLayer");

            UIElement runnerHPBar = Instantiate(ResourceLoader.uiElementLoader.GetObj(UIElementType.RUNNER_HP_BAR)) as RunnerHPBar;
            AddUIElement(runnerHPBar);
            runnerHPBar.transform.SetParent(this.transform, false);
            runnerHPBar.messageHandler = new RunnerHPMessageHandler(runnerHPBar as RunnerHPBar);
            runnerHPBar.InitElement();
        }
    }
}