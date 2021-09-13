using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class BaseClientControl : MonoBehaviour
    {
        static BaseClientControl _current = null;

        [SerializeField]
        protected string _hostIP = string.Empty;

        protected bool _connectionFailed = false;

        public static BaseClientControl CURRENT
        {
            get
            {
                return _current;
            }
        }

        public bool CONNECTION_FAILED
        {
            get
            {
                return _connectionFailed;
            }
        }

        public static void SetClientControl(BaseClientControl control)
        {
            _current = control;
        }

        public virtual void SetHostIP(string ip)
        {
            _hostIP = ip;
        }

        public virtual string GetHostIP()
        {
            if (string.IsNullOrEmpty(_hostIP))
            {
                _hostIP = "127.0.0.1";
            }

            return _hostIP;
        }

        public virtual void ConnectToServer()
        {

        }

        public virtual string GetUserName()
        {
            return string.Empty;
        }

        public virtual int GetClientIndex()
        {
            return 0;
        }

        public virtual void ShowMenu()
        {

        }

        public virtual void QueueConnectionFailedMessage()
        {

        }

        public virtual void HideMenu()
        {

        }

        public virtual void UpdateClientConnectionStatus(ClientConnection[] arr)
        {

        }
    }
}