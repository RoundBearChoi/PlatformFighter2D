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
            
            if (RB.Server.ServerManager.CURRENT != null)
            {
                RB.Server.ServerManager.CURRENT.serverController.Stop();
                Destroy(RB.Server.ServerManager.CURRENT.gameObject);
            }

            if (RB.Client.ClientManager.CURRENT != null)
            {
                RB.Client.ClientManager.CURRENT.DisconnectClient();
                Destroy(RB.Client.ClientManager.CURRENT.gameObject);
            }
        }
    }
}