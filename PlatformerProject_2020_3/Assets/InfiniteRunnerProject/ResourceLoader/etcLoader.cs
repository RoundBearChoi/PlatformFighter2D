namespace RB
{
    public class etcLoader : GameResources<etcType>
    {
        public etcLoader()
        {
            Debugger.Log("loading other stuff..");

            LoadObj<IntroCamera>(etcType.INTRO_CAMERA, "IntroCamera");
            LoadObj<GameCamera>(etcType.GAME_CAMERA, "GameCamera");
            LoadObj<FightCamera>(etcType.FIGHT_CAMERA, "FightCamera");
            LoadObj <ModelFightCamera>(etcType.MODEL_FIGHT_CAMERA, "ModelFightCamera");

            LoadObj<RB.Server.ServerManager>(etcType.SERVER_MANAGER, "ServerManager");
            LoadObj<RB.Server.ServerController>(etcType.SERVER_CONTROLLER, "ServerController");

            LoadObj<RB.Client.ClientManager>(etcType.CLIENT_MANAGER, "ClientManager");
            LoadObj<RB.Client.ClientController>(etcType.CLIENT_CONTROLLER, "ClientController");
            LoadObj<RB.Client.ClientInputSender>(etcType.CLIENT_INPUT, "ClientInputSender");

            LoadObj<ConnectedPlayerInfo>(etcType.CONNECTED_PLAYER_INFO, "ConnectedPlayerInfo");

            LoadObj<RB.Client.ClientObject>(etcType.CLIENT_OBJECT, "ClientObject");
        }
    }
}