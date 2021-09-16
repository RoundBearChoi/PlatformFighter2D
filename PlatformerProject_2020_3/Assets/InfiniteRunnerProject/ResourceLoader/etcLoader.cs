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

            LoadObj<EnemyHPBar>(etcType.HP_BAR, "EnemyHPBar");

            LoadObj<RB.Server.ServerControl>(etcType.SERVER_CONTROL, "ServerControl");
            LoadObj<RB.Client.ClientManager>(etcType.CLIENT_MANAGER, "ClientManager");
            LoadObj<RB.Client.ClientController>(etcType.CLIENT_CONTROLLER, "ClientController");
            LoadObj<RB.Client.ClientInput>(etcType.CLIENT_INPUT, "ClientInput");

            LoadObj<ConnectedPlayerInfo>(etcType.CONNECTED_PLAYER_INFO, "ConnectedPlayerInfo");

            LoadObj<RB.Client.ClientObject>(etcType.CLIENT_OBJECT, "ClientObject");
        }
    }
}