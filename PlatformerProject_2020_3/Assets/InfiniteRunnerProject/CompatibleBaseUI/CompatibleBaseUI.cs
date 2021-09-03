using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CompatibleBaseUI : BaseUI
    {
        public override void Init(BaseUIType baseUIType)
        {
            if (baseUIType == BaseUIType.FIGHTER_INTRO_UI)
            {
                IntroSelectionLayer introSelectionLayer = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.INTRO_SELECTION_LAYER)) as IntroSelectionLayer;
                AddUILayer(introSelectionLayer);
                introSelectionLayer.transform.SetParent(CANVAS.transform, false);
                introSelectionLayer.InitLayer();
            }
            else if (baseUIType == BaseUIType.RUNNER_GAME_UI)
            {
                RunnerInfoLayer basicInfoLayer = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.RUNNER_INFO_LAYER)) as RunnerInfoLayer;
                AddUILayer(basicInfoLayer);
                basicInfoLayer.transform.SetParent(CANVAS.transform, false);
                basicInfoLayer.InitLayer();
            }
        }
    }
}