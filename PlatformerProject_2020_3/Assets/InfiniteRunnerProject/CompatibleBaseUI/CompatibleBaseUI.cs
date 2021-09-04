using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CompatibleBaseUI : BaseUI
    {
        public override void Init(BaseUIType baseUIType)
        {
            if (baseUIType == BaseUIType.RUNNER_GAME_UI)
            {
                CompatibleUILayer layer = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_UI_LAYER)) as CompatibleUILayer;
                AddUILayer(layer);
                layer.transform.SetParent(CANVAS.transform, false);
                layer.InitLayer(UILayerType.RUNNER_INFO);
            }

            else if (baseUIType == BaseUIType.FIGHTER_INTRO_UI)
            {
                CompatibleUILayer layer = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_UI_LAYER)) as CompatibleUILayer;
                AddUILayer(layer);
                layer.transform.SetParent(CANVAS.transform, false);
                layer.InitLayer(UILayerType.INTRO_SELECTION);
            }

            else if (baseUIType == BaseUIType.HOST_GAME_UI)
            {
                CompatibleUILayer layer = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_UI_LAYER)) as CompatibleUILayer;
                AddUILayer(layer);
                layer.transform.SetParent(CANVAS.transform, false);
                layer.InitLayer(UILayerType.HOST_GAME);
            }

            else if (baseUIType == BaseUIType.ENTER_IP_UI)
            {
                CompatibleUILayer layer = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_UI_LAYER)) as CompatibleUILayer;
                AddUILayer(layer);
                layer.transform.SetParent(CANVAS.transform, false);
                layer.InitLayer(UILayerType.ENTER_IP);
            }
        }
    }
}