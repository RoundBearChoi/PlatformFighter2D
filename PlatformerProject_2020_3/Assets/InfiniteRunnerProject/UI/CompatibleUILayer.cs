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
                UIElement runnerHPBar = UIElement.AddUIElement(UIElementType.RUNNER_HP_BAR, this.transform);
                _uiElements.Add(runnerHPBar);

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

                UIElement waiting = UIElement.AddUIElement(UIElementType.WAITING_FOR_PLAYERS, this.transform);
                _uiElements.Add(waiting);

                UIElement connected = UIElement.AddUIElement(UIElementType.CONNECTED_UI, this.transform);
                _uiElements.Add(connected);

                UIElement serverIP = UIElement.AddUIElement(UIElementType.SERVER_IP, this.transform);
                _uiElements.Add(serverIP);
                serverIP.InitElement();
                serverIP.messageHandler = new ServerIPMessageHandler();
            }

            else if (uiLayerType == UILayerType.ENTER_IP)
            {
                UIElement enter = UIElement.AddUIElement(UIElementType.ENTER_HOST_IP, this.transform);
                _uiElements.Add(enter);

                enter.messageHandler = new EnterHostIPMessageHandler();
            }

            else if (uiLayerType == UILayerType.CONNECTING_TO_HOST)
            {
                UIElement connecting = UIElement.AddUIElement(UIElementType.CONNECTING_TO_HOST, this.transform);
                _uiElements.Add(connecting);
            }

            else if (uiLayerType == UILayerType.CONNECTED_UI)
            {
                UIElement connected = UIElement.AddUIElement(UIElementType.CONNECTED_UI, this.transform);
                _uiElements.Add(connected);
            }

            else if (uiLayerType == UILayerType.FIGHT_STAGE_LAYER)
            {
                UIElement onESC = UIElement.AddUIElement(UIElementType.ON_ESC, this.transform);
                _uiElements.Add(onESC);
                onESC.InitElement();
            }
        }
    }
}