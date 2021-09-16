using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class ClientManager : MonoBehaviour
    {
        public static ClientManager CURRENT = null;

        public ClientController clientController = null;
        private ClientInput clientInput = null;

        [SerializeField]
        ClientConnection[] _clientConnections = null;

        [SerializeField]
        protected TargetIP _targetIP = null;
        protected bool _connectionFailed = false;

        public bool CONNECTION_FAILED
        {
            get
            {
                return _connectionFailed;
            }
        }

        public virtual void SetHostIP(string ip)
        {
            _targetIP.hostIP = ip;
        }

        public virtual string GetHostIP()
        {
            if (string.IsNullOrEmpty(_targetIP.hostIP))
            {
                _targetIP.hostIP = "127.0.0.1";
            }

            return _targetIP.hostIP;
        }

        public virtual void ConnectToServer()
        {
            _connectionFailed = false;
            _clientConnections = new[] {
                new ClientConnection (999, false),
                new ClientConnection (999, false),
                new ClientConnection (999, false),};

            if (clientController == null)
            {
                clientController = Instantiate(ResourceLoader.etcLoader.GetObj(etcType.CLIENT_CONTROLLER)) as ClientController;
                clientController.transform.SetParent(this.transform, false);

                clientInput = Instantiate(ResourceLoader.etcLoader.GetObj(etcType.CLIENT_INPUT)) as ClientInput;
                clientInput.transform.SetParent(this.transform, true);
            }

            string hostIP = GetHostIP();
            clientController.ConnectToServer(hostIP);
        }

        public virtual string GetUserName()
        {
            return string.Empty;
        }

        public virtual void ShowEnterIPUI()
        {
            BaseInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.ENTER_IP_STAGE));
        }

        public virtual void QueueConnectionFailedMessage()
        {
            _connectionFailed = true;
        }

        public virtual void UpdateClientConnectionStatus(ClientConnection[] arr)
        {
            _clientConnections = arr;
        }

        public virtual ClientConnection[] GetClientConnectionStatus()
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
                Destroy(this.gameObject);
            });
        }
    }
}