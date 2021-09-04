using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    public class BaseNetwork : MonoBehaviour
    {
        public Server server = null;
        public ServerSend serverSend = null;

        private static BaseNetwork _current = null;

        public static BaseNetwork CURRENT
        {
            get
            {
                return _current;
            }
        }

        public static void SetCurrent(BaseNetwork baseNetwork)
        {
            _current = baseNetwork;
        }
    }
}