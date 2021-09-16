using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ReturnToMenu : UIOption
    {
        public override void OnEnterKey()
        {
            Debugger.Log("returning to menu");
            BaseInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.INTRO_STAGE));
            
            if (RB.Server.ServerControl.CURRENT != null)
            {
                RB.Server.ServerControl.CURRENT.server.Stop();
                Destroy(RB.Server.ServerControl.CURRENT.gameObject);
            }

            if (RB.Client.ClientManager.CURRENT != null)
            {
                RB.Client.ClientManager.CURRENT.client.DisconnectClient();
                Destroy(RB.Client.ClientManager.CURRENT.gameObject);
            }
        }
    }
}