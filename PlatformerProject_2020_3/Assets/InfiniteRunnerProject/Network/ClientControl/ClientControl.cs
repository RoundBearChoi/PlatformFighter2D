using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class ClientControl : BaseClientControl
    {
        public static FighterClient fighterClient = null;

        public override void ConnectToServer()
        {
            if (fighterClient == null)
            {
                fighterClient = Instantiate(ResourceLoader.etcLoader.GetObj(etcType.FIGHTER_CLIENT)) as FighterClient;
                fighterClient.transform.SetParent(this.transform, true);
            }

            string hostIP = GetHostIP();
            Client.instance.ConnectToServer(hostIP);
        }
    }
}