using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class ClientManager : MonoBehaviour
    {
        static ClientManager _current = null;

        public ClientController clientController = null;
        public ClientInputSender clientInput = null;

        [SerializeField]
        ClientConnection[] _clientConnections = null;

        [SerializeField]
        TargetIP _targetIP = null;

        public static ClientManager CURRENT
        {
            get
            {
                return _current;
            }
        }

        public static void Init()
        {
            if (_current != null)
            {
                Destroy(_current.gameObject);
            }

            _current = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.CLIENT_MANAGER)) as ClientManager;

            _current.clientController = Instantiate(ResourceLoader.etcLoader.GetObj(etcType.CLIENT_CONTROLLER)) as ClientController;
            _current.clientController.transform.SetParent(_current.transform, false);

            _current.clientInput = Instantiate(ResourceLoader.etcLoader.GetObj(etcType.CLIENT_INPUT)) as ClientInputSender;
            _current.clientInput.transform.SetParent(_current.transform, true);
        }

        public void SetHostIP(string ip)
        {
            _targetIP.hostIP = ip;
        }

        public string GetHostIP()
        {
            if (string.IsNullOrEmpty(_targetIP.hostIP))
            {
                _targetIP.hostIP = "127.0.0.1";
            }

            return _targetIP.hostIP;
        }

        public void ConnectToServer()
        {
            _clientConnections = new[] {
                new ClientConnection (999, false),
                new ClientConnection (999, false),
                new ClientConnection (999, false),};

            string hostIP = GetHostIP();
            clientController.ConnectToServer(hostIP);
        }

        public string GetUserName()
        {
            return "no name";
        }

        public void UpdateClientConnectionStatus(ClientConnection[] arr)
        {
            _clientConnections = arr;
        }

        public ClientConnection[] GetClientConnectionStatus()
        {
            return _clientConnections;
        }

        public void EndClient()
        {
            try
            {
                clientController.clientTCP.TCP_CLIENT.Close();
                clientController.clientUDP.UDP_CLIENT.Close();
            }
            catch (System.Exception e)
            {
                Debugger.Log("system error attempting to close socket: " + e);
            }

            Debug.Log("client ended");

            BaseStage currentStage = BaseInitializer.current.STAGE;

            if (currentStage != null)
            {
                if (currentStage is MultiplayerClientStage ||
                    currentStage is ConnectedStage)
                {
                    Debugger.Log("returning to menu");
                    BaseInitializer.current.stageTransitioner.AddNextStage(GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(StageType.INTRO_STAGE)) as BaseStage);
                }
            }
        }
    }
}