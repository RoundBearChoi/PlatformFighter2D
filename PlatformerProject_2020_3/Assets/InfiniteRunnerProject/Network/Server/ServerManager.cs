using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    public class ServerManager : MonoBehaviour
    {
        public Server server = null;
        public ServerSend serverSend = null;

        private static ServerManager _current = null;

        public static void Init()
        {
            //destroy existing
            if (_current != null)
            {
                Destroy(_current.gameObject);
            }

            //can either be server or client
            if (RB.Client.ClientManager.CURRENT != null)
            {
                Destroy(RB.Client.ClientManager.CURRENT.gameObject);
            }

            _current = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.SERVER_MANAGER)) as RB.Server.ServerManager;

            _current.server = new Server();
            _current.server.OpenServer();

            _current.serverSend = new ServerSend();
        }

        public static ServerManager CURRENT
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