using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    public class BaseClientControl : MonoBehaviour
    {
        static BaseClientControl _current = null;

        [SerializeField]
        string _hostIP = string.Empty;

        public static BaseClientControl CURRENT
        {
            get
            {
                return _current;
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
            return _hostIP;
        }
    }
}