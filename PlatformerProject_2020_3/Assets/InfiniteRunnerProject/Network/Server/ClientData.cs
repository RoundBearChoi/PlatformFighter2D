using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using RB.Network;

namespace RB.Server
{
    [Serializable]
    public class ClientData
    {
        public static int dataBufferSize = 4096;

        [SerializeField]
        string _name = string.Empty;

        public ServerTCP serverTCP;
        public ServerUDP serverUDP;

        [Header("Debug")]
        [SerializeField]
        bool[] _inputs = null;

        public ClientData(int clientId)
        {
            serverTCP = new ServerTCP(clientId);
            serverUDP = new ServerUDP(clientId);
        }

        public void Disconnect()
        {
            Debug.Log($"{serverTCP.socket.Client.RemoteEndPoint} has disconnected.");

            //disconnect TCP & UDP endpoint
            serverTCP.Disconnect();
            serverUDP.ipEndPoint = null;

            ThreadManager.ExecuteOnMainThread(() =>
            {
                ServerManager.CURRENT.server.connectedClients.RemoveClient(this);
                ServerManager.CURRENT.serverSend.ClientsConnectionStatus();
            });
        }

        public void SetInput(bool[] inputs)
        {
            _inputs = inputs;
        }

        public void SetUserName(string name)
        {
            _name = name;
        }
    }
}