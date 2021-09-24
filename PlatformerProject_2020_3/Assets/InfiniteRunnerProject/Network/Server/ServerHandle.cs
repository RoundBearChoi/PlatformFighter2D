using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Network;

namespace RB.Server
{
    public class ServerHandle
    {
        public static void WelcomeReceived(int IDReceivedFromClient, Packet _packet)
        {
            try
            {
                int clientIdCheck = _packet.ReadInt();
                string username = _packet.ReadString();

                ClientData data = ServerManager.CURRENT.serverController.clients.GetClientData(IDReceivedFromClient);
                Debugger.Log(data.serverTCP.socket.Client.RemoteEndPoint + " connected successfully and is now player " + IDReceivedFromClient);
                Debugger.Log("user name: " + username);

                if (IDReceivedFromClient != clientIdCheck)
                {
                    Debugger.Log("player " + username + "ID: " + IDReceivedFromClient + " has assumed the wrong client ID " + clientIdCheck);
                }

                data.SetUserName(username);
            }
            catch(System.Exception e)
            {
                Debugger.Log("system error on welcome received: " + e);
            }
        }

        public static void HandleClientInput(int clientID, Packet packet)
        {
            int length = packet.ReadInt();
            bool[] inputs = new bool[length];

            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = packet.ReadBool();
            }

            ClientData clientData = ServerManager.CURRENT.serverController.clients.GetClientData(clientID);

            if (clientData != null)
            {
                clientData.UpdateOnClientInput(clientID, inputs);
            }
        }
    }
}