using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CompatibleUILayer : UILayer
    {
        public override void InitLayer(UILayerType uiLayerType)
        {
            if (uiLayerType == UILayerType.RUNNER_INFO)
            {
                UIElement runnerHPBar = Instantiate(ResourceLoader.uiElementLoader.GetObj(UIElementType.RUNNER_HP_BAR)) as RunnerHPBar;

                AddUIElement(runnerHPBar);
                runnerHPBar.transform.SetParent(this.transform, false);
                runnerHPBar.InitElement();

                runnerHPBar.messageHandler = new RunnerHPMessageHandler(runnerHPBar as RunnerHPBar);
            }

            else if (uiLayerType == UILayerType.INTRO_SELECTION)
            {
                UISelection introSelect = Instantiate(ResourceLoader.etcLoader.GetObj(etcType.INTRO_SELECT)) as UISelection;

                AddUISelection(introSelect);
                introSelect.transform.SetParent(this.transform, false);
                introSelect.InitSelection();
            }

            else if (uiLayerType == UILayerType.HOST_GAME)
            {
                HostGameSelect hostGameSelect = Instantiate(ResourceLoader.etcLoader.GetObj(etcType.HOST_GAME_SELECT)) as HostGameSelect;

                AddUISelection(hostGameSelect);
                hostGameSelect.transform.SetParent(this.transform, false);
                hostGameSelect.InitSelection();
            }
        }
    }
}