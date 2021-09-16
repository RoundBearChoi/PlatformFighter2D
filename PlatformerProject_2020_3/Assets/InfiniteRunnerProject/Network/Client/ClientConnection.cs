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

        public static ClientConnection[] GetData(RB.Server.ClientData[] clients)
        {
            ClientConnection[] connections = new[] {
                new ClientConnection (999, false),
                new ClientConnection (999, false),
                new ClientConnection (999, false),};

            for (int i = 0; i < 3; i++)
            {
                if (clients.Length > i)
                {
                    connections[i] = new ClientConnection(clients[i].serverTCP.ID, true);
                }
                else
                {
                    connections[i] = new ClientConnection(999, false);
                }
            }

            return connections;
        }
    }
}