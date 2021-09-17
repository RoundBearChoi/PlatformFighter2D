using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    public class ServerManager : MonoBehaviour
    {
        public ServerController serverController = null;
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

            _current.serverController = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.SERVER_CONTROLLER)) as ServerController;
            _current.serverController.transform.SetParent(_current.transform, true);

            _current.serverController.OpenServer();

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
            serverController.EndServer();
        }
    }
}