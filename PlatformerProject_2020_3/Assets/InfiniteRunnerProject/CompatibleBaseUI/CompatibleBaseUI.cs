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
                AddCompatibleUILayer(UILayerType.RUNNER_INFO);
            }

            else if (baseUIType == BaseUIType.FIGHTER_INTRO_UI)
            {
                AddCompatibleUILayer(UILayerType.INTRO_SELECTION);
            }

            else if (baseUIType == BaseUIType.HOST_GAME_UI)
            {
                AddCompatibleUILayer(UILayerType.HOST_GAME);
            }

            else if (baseUIType == BaseUIType.ENTER_IP_UI)
            {
                AddCompatibleUILayer(UILayerType.ENTER_IP);
            }

            else if (baseUIType == BaseUIType.CONNECTING_UI)
            {
                AddCompatibleUILayer(UILayerType.CONNECTING_TO_HOST);
            }

            else if (baseUIType == BaseUIType.CONNECTED_UI)
            {
                AddCompatibleUILayer(UILayerType.CONNECTED_UI);
            }

            else if (baseUIType == BaseUIType.FIGHT_STAGE_UI)
            {
                AddCompatibleUILayer(UILayerType.FIGHT_STAGE_LAYER);
            }

            else if (baseUIType == BaseUIType.FIGHT_STAGE_CLIENT_UI)
            {
                AddCompatibleUILayer(UILayerType.FIGHT_STAGE_CLIENT_LAYER);
            }

            else if (baseUIType == BaseUIType.INPUT_DEVICES_STAGE_UI)
            {
                AddCompatibleUILayer(UILayerType.INPUT_DEVICES_STAGE_LAYER);
            }
        }
    }
}