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

        [SerializeField]
        bool[] _inputs = null;

        public ServerTCP serverTCP;
        public ServerUDP serverUDP;

        public ClientData(int clientId)
        {
            serverTCP = new ServerTCP(clientId);
            serverUDP = new ServerUDP(clientId);
        }

        public void Disconnect()
        {
            Debugger.Log(serverTCP.socket.Client.RemoteEndPoint + " has disconnected");

            serverTCP.Disconnect();
            serverUDP.ipEndPoint = null;

            ThreadControl.ExecuteOnMainThread(() =>
            {
                ServerManager.CURRENT.serverController.clients.RemoveClient(this);
                ServerManager.CURRENT.serverSend.ClientsConnectionStatus();
            });
        }

        public void UpdateOnClientInput(int clientIndex, bool[] arrInputs)
        {
            _inputs = arrInputs;

            UserInput input = BaseInitializer.current.GetStage().GetUserInputByClientIndex(clientIndex);

            if (input != null)
            {
                input.commands.UpdatePressAndHold(_inputs);
            }
        }

        public void SetUserName(string name)
        {
            _name = name;
        }
    }
}