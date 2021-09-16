using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class BaseClientControl : MonoBehaviour
    {
        static BaseClientControl _current = null;

        [SerializeField]
        protected TargetIP _targetIP = null;

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

        }

        public virtual string GetUserName()
        {
            return string.Empty;
        }

        public virtual int GetClientIndex()
        {
            return 0;
        }

        public virtual void ShowEnterIPUI()
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

        public virtual ClientConnection[] GetClientConnectionStatus()
        {
            return null;
        }
    }
}