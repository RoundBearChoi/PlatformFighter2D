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

        public static void Init()
        {
            if (_current == null)
            {
                _current = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.SERVER_CONTROL)) as RB.Server.ServerControl;
            }

            _current.server = new Server();
            _current.server.OpenServer();

            _current.serverSend = new ServerSend();
        }

        public static ServerControl CURRENT
        {
            get
            {
                return _current;
            }
        }

        private void OnApplicationQuit()
        {
            server.Stop();
        }
    }
}