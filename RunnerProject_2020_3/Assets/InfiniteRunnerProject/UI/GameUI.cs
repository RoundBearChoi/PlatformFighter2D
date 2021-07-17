using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameUI : BaseUI
    {
        public override void Init()
        {
            BasicInfoLayer basicInfoLayer = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.BASIC_INFO_LAYER)) as BasicInfoLayer;
            AddUILayer(basicInfoLayer);
            basicInfoLayer.transform.SetParent(CANVAS.transform, false);
            basicInfoLayer.InitLayer();
        }
    }
}