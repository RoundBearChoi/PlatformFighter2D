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
            server.OpenServer(26950);

            serverSend = new ServerSend();
        }

        private void OnApplicationQuit()
        {
            server.Stop();
        }

        //public PlayerData InstantiatePlayer()
        //{
        //    return Instantiate(playerPrefab, new Vector3(0f, 0.5f, 0f), Quaternion.identity).GetComponent<PlayerData>();
        //}
    }
}