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
            if (NetworkControl.CURRENT != null)
            {
                foreach(ClientData data in NetworkControl.CURRENT.server.clients)
                {
                    if (data.tcp != null)
                    {
                        Debugger.Log("can't join while running a server");
                        return;
                    }
                }
            }

            GameInitializer.current.stageTransitioner.AddTransition(new EnterIPStageTransition(GameInitializer.current));
        }
    }
}