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
            //destroy existing
            if (_current != null)
            {
                Destroy(_current.gameObject);
            }

            //can either be server or client
            if (RB.Server.ServerManager.CURRENT != null)
            {
                Destroy(RB.Server.ServerManager.CURRENT.gameObject);
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

        public void ShowEnterIPUI()
        {
            BaseInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.ENTER_IP_STAGE));
        }

        public void UpdateClientConnectionStatus(ClientConnection[] arr)
        {
            _clientConnections = arr;
        }

        public ClientConnection[] GetClientConnectionStatus()
        {
            return _clientConnections;
        }

        public void DisconnectClient()
        {
            if (clientController.clientTCP.SOCKET != null)
            {
                if (clientController.clientTCP.SOCKET.Connected)
                {
                    clientController.clientTCP.SOCKET.Close();
                    clientController.clientUDP.SOCKET.Close();
                }
            }

            Debug.Log("Disconnected from server.");

            RB.Network.ThreadManager.ExecuteOnMainThread(() =>
            {
                Debugger.Log("returning to menu");

                //do this separately
                //show notification instead, and then switch to intro stage
                //BaseInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.INTRO_STAGE));
            });
        }
    }
}