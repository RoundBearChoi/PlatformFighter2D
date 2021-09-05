using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    public class BaseNetworkControl : MonoBehaviour
    {
        public Server server = null;
        public ServerSend serverSend = null;

        private static BaseNetworkControl _current = null;

        public static BaseNetworkControl CURRENT
        {
            get
            {
                return _current;
            }
        }

        public static void SetCurrent(BaseNetworkControl baseNetwork)
        {
            _current = baseNetwork;
        }
    }
}