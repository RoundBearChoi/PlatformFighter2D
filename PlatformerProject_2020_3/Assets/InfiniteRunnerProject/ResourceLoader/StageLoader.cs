using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class StageLoader : GameResources<StageType>
    {
        public StageLoader()
        {
            Debugger.Log("loading stages..");

            LoadObj<IntroStage>(StageType.INTRO_STAGE, "IntroStage");
            LoadObj<TestStage>(StageType.TEST_STAGE, "TestStage");
            LoadObj<SpriteStage>(StageType.SPRITE_STAGE, "SpriteStage");

            LoadObj<InputDevicesStage>(StageType.INPUT_DEVICES_STAGE, "InputDevicesStage");
            LoadObj<FightStage>(StageType.FIGHT_STAGE, "FightStage");
            LoadObj<MultiplayerServerStage>(StageType.MULTIPLAYER_SERVER_STAGE, "MultiplayerServerStage");
            LoadObj<MultiplayerClientStage>(StageType.MULTIPLAYER_CLIENT_STAGE, "MultiplayerClientStage");

            LoadObj<HostGameStage>(StageType.HOST_GAME_STAGE, "HostGameStage");
            LoadObj<EnterHostIPStage>(StageType.ENTER_IP_STAGE, "EnterHostIPStage");
            LoadObj<ConnectingStage>(StageType.CONNECTING_STAGE, "ConnectingStage");
            LoadObj<ConnectedStage>(StageType.CONNECTED_STAGE, "ConnectedStage");
        }
    }
}