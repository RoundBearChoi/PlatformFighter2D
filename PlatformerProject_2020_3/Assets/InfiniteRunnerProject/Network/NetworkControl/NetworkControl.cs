using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    public class NetworkControl : BaseNetworkControl
    {
        private void Start()
        {
            SetCurrent(this);

            server = new Server();
            server.OpenServer(26950);

            serverSend = new ServerSend();
        }

        private void OnApplicationQuit()
        {
            server.Stop();
        }
    }
}