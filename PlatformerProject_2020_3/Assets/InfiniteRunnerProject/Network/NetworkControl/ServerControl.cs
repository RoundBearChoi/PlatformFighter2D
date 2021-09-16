using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    public class ServerControl : BaseServerControl
    {
        private void Start()
        {
            SetCurrent(this);

            server = new Server();
            server.OpenServer();

            serverSend = new ServerSend();
        }

        private void OnApplicationQuit()
        {
            server.Stop();
        }
    }
}