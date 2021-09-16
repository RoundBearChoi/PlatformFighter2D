using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Server;

namespace RB
{
    public class JoinGame : UIOption
    {
        public override void OnEnterKey()
        {
            if (BaseServerControl.CURRENT != null)
            {
                if (BaseServerControl.CURRENT.server.connectedClients.CLIENTS_COUNT > 0)
                {
                    Debugger.Log("can't join while running a server");
                    return;
                }
            }

            //also gotta check if you're already connected to a server

            BaseInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.ENTER_IP_STAGE));
        }
    }
}