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
                UIElement runnerHPBar = AddUIElement(UIElementType.RUNNER_HP_BAR);
                runnerHPBar.messageHandler = new RunnerHPMessageHandler(runnerHPBar as RunnerHPBar);
            }

            else if (uiLayerType == UILayerType.INTRO_SELECTION)
            {
                UISelection introSelect = UISelection.AddUISelection(UIType.INTRO_SELECT, this.transform);
                _uiSelection = introSelect;
            }

            else if (uiLayerType == UILayerType.HOST_GAME)
            {
                UISelection hostGameSelect = UISelection.AddUISelection(UIType.HOST_GAME_SELECT, this.transform);
                _uiSelection = hostGameSelect;

                AddUIElement(UIElementType.WAITING_FOR_PLAYERS);
                AddUIElement(UIElementType.CONNECTED_UI);

                UIElement serverIP = AddUIElement(UIElementType.SERVER_IP);
                serverIP.InitElement();
                serverIP.messageHandler = new ServerIPMessageHandler();
            }

            else if (uiLayerType == UILayerType.ENTER_IP)
            {
                UIElement enter = AddUIElement(UIElementType.ENTER_HOST_IP);
                enter.messageHandler = new EnterHostIPMessageHandler();
            }

            else if (uiLayerType == UILayerType.CONNECTING_TO_HOST)
            {
                UIElement connecting = AddUIElement(UIElementType.CONNECTING_TO_HOST);
            }

            else if (uiLayerType == UILayerType.CONNECTED_UI)
            {
                UIElement connected = AddUIElement(UIElementType.CONNECTED_UI);
            }

            else if (uiLayerType == UILayerType.FIGHT_STAGE_LAYER)
            {
                UIElement onESC = AddUIElement(UIElementType.ON_ESC);
                onESC.InitElement();
            }
        }
    }
}