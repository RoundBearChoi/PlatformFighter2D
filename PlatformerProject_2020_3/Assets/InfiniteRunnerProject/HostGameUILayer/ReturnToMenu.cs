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
            
            if (RB.Server.NetworkControl.CURRENT != null)
            {
                RB.Server.NetworkControl.CURRENT.server.Stop();
                Destroy(RB.Server.NetworkControl.CURRENT.gameObject);
            }
        }
    }
}