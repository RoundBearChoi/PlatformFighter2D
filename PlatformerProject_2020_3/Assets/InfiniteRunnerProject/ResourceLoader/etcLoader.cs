using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            LoadObj<RB.Server.NetworkControl>(etcType.NETWORK_CONTROL, "NetworkControl");
            LoadObj<RB.Client.ClientControl>(etcType.CLIENT_CONTROL, "ClientControl");
            LoadObj<RB.Client.FighterClient>(etcType.FIGHTER_CLIENT, "FighterClient");

            LoadObj<ConnectedPlayerInfo>(etcType.CONNECTED_PLAYER_INFO, "ConnectedPlayerInfo");
        }
    }
}