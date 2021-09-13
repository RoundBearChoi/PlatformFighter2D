using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    [System.Serializable]
    public struct ClientConnection
    {
        public ClientConnection(int index, bool connected)
        {
            mIndex = index;
            mConnected = connected;
        }

        public int mIndex;
        public bool mConnected;
    }
}