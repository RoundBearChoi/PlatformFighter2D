using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    public class NetworkManager : BaseNetworkControl
    {
        private void Start()
        {
            SetCurrent(this);

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 30;

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