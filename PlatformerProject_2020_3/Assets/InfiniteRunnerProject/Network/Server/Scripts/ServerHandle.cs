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
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            ClientData data = BaseNetworkControl.CURRENT.server.connectedClients.GetClientData(IDReceivedFromClient);
            Debug.Log($"{data.tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {IDReceivedFromClient}.");
            
            if (IDReceivedFromClient != _clientIdCheck)
            {
                Debug.Log($"Player \"{_username}\" (ID: {IDReceivedFromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
            }

            data.SetUserName(_username);
        }

        public static void PlayerMovement(int fromClient, Packet packet)
        {
            bool[] inputs = new bool[packet.ReadInt()];

            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = packet.ReadBool();
            }

            ClientData data = BaseNetworkControl.CURRENT.server.connectedClients.GetClientData(fromClient);
            data.SetInput(inputs);

            //BaseNetworkControl.CURRENT.server.clients[fromClient].SetInput(inputs);
        }
    }
}