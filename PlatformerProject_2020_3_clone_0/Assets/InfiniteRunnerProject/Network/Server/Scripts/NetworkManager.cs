using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    public class NetworkManager : MonoBehaviour
    {
        public static NetworkManager instance;

        public Server server = null;
        public ServerSend serverSend = null;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Debug.Log("Instance already exists, destroying object!");
                Destroy(this);
            }
        }

        private void Start()
        {
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