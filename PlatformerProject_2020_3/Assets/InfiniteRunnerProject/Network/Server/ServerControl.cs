using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    public class ServerControl : MonoBehaviour
    {
        public Server server = null;
        public ServerSend serverSend = null;

        private static ServerControl _current = null;

        private void Start()
        {
            SetCurrent(this);

            server = new Server();
            server.OpenServer();

            serverSend = new ServerSend();
        }

        public static ServerControl CURRENT
        {
            get
            {
                return _current;
            }
        }

        public static void SetCurrent(ServerControl baseNetwork)
        {
            _current = baseNetwork;
        }

        private void OnApplicationQuit()
        {
            server.Stop();
        }
    }
}