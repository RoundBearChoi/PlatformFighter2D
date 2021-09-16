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
            int clientIdCheck = _packet.ReadInt();
            string username = _packet.ReadString();

            ClientData data = ServerManager.CURRENT.server.connectedClients.GetClientData(IDReceivedFromClient);
            Debug.Log($"{data.serverTCP.socket.Client.RemoteEndPoint} connected successfully and is now player {IDReceivedFromClient}.");
            
            if (IDReceivedFromClient != clientIdCheck)
            {
                Debug.Log($"Player \"{username}\" (ID: {IDReceivedFromClient}) has assumed the wrong client ID ({clientIdCheck})!");
            }

            data.SetUserName(username);
        }

        public static void HandleClientInput(int fromClient, Packet packet)
        {
            int length = packet.ReadInt();
            bool[] inputs = new bool[length];

            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = packet.ReadBool();
            }

            ClientData data = ServerManager.CURRENT.server.connectedClients.GetClientData(fromClient);

            if (data != null)
            {
                data.SetInput(inputs);
                BaseInitializer.current.GetStage().UpdateOnClientInput(fromClient, inputs);
            }
        }

        public static void HandleUDPCheck(int fromClient, Packet packet)
        {

        }
    }
}