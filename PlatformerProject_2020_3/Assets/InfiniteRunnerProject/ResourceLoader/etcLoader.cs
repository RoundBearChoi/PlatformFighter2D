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
            LoadObj<RB.Client.ClientControl>(etcType.CLIENT_CONTROL, "ClientControl");
            LoadObj<RB.Client.Client>(etcType.CLIENT, "Client");
            LoadObj<RB.Client.ClientInput>(etcType.CLIENT_INPUT, "ClientInput");

            LoadObj<ConnectedPlayerInfo>(etcType.CONNECTED_PLAYER_INFO, "ConnectedPlayerInfo");

            LoadObj<RB.Client.ClientObject>(etcType.CLIENT_OBJECT, "ClientObject");
        }
    }
}