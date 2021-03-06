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

            LoadObj<GameVersion>(UIElementType.GAME_VERSION, "GameVersion");

            //LoadObj<RB.Server.WaitingForPlayers>(UIElementType.WAITING_FOR_PLAYERS, "WaitingForPlayers");
            LoadObj<RB.Server.ServerIP>(UIElementType.SERVER_IP, "ServerIP");

            LoadObj<EnterHostIP>(UIElementType.ENTER_HOST_IP, "EnterHostIP");
            LoadObj<ConnectingToHost>(UIElementType.CONNECTING_TO_HOST, "ConnectingToHost");
            LoadObj<ConnectedUI>(UIElementType.CONNECTED_UI, "ConnectedUI");

            LoadObj<OnESC>(UIElementType.ON_ESC, "OnESC");
            LoadObj<FightersHP>(UIElementType.FIGHTERS_HP, "FightersHP");
            LoadObj<DetectedInputDevices>(UIElementType.DETECTED_INPUT_DEVICES, "DetectedInputDevices");
            LoadObj<PickFighters>(UIElementType.PICK_FIGHTERS, "PickFighters");
            LoadObj<PressEnterToStart>(UIElementType.PRESS_ENTER_TO_START, "PressEnterToStart");

            LoadObj<QuitGameAsk>(UIElementType.QUIT_GAME_ASK, "QuitGameAsk");
        }
    }
}