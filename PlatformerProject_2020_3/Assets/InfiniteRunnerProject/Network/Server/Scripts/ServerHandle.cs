using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Network;

namespace RB.Server
{
    public class ServerHandle
    {
        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Debug.Log($"{BaseNetwork.CURRENT.server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
            
            if (_fromClient != _clientIdCheck)
            {
                Debug.Log($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
            }

            BaseNetwork.CURRENT.server.clients[_fromClient].SetUserName(_username);
        }

        public static void PlayerMovement(int fromClient, Packet packet)
        {
            bool[] inputs = new bool[packet.ReadInt()];

            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = packet.ReadBool();
            }

            BaseNetwork.CURRENT.server.clients[fromClient].SetInput(inputs);
        }
    }
}