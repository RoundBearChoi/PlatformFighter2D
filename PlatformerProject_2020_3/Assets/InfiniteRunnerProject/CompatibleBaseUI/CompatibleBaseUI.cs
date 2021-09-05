using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CompatibleBaseUI : BaseUI
    {
        IEnumerator _startEventSystem()
        {
            _eventSystem = this.gameObject.GetComponentInChildren<UnityEngine.EventSystems.EventSystem>();
            _eventSystem.gameObject.SetActive(false);
            CANVAS.enabled = false;

            yield return new WaitForEndOfFrame();
            
            _eventSystem.gameObject.SetActive(true);
            CANVAS.enabled = true;
        }

        public override void Init(BaseUIType baseUIType)
        {
            StartCoroutine(_startEventSystem());

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