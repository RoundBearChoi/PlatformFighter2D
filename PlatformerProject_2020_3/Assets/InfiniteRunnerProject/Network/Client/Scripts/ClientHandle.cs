using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using RB.Network;

namespace RB.Client
{
    public class ClientHandle : MonoBehaviour
    {
        public static void Welcome(Packet packet)
        {
            string msg = packet.ReadString();
            int myId = packet.ReadInt();

            Debug.Log($"Message from server: {msg}");
            Client.instance.myId = myId;
            ClientSend.WelcomeReceived();

            // Now that we have the client's id, connect UDP
            Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);

            //message to game
            BaseMessage connectedMessage = new Message_ConnectedToServer();
            connectedMessage.Register();
        }

        public static void SpawnPlayer(Packet packet)
        {
            int id = packet.ReadInt();
            string username = packet.ReadString();
            Vector3 position = packet.ReadVector3();
            Quaternion rotation = packet.ReadQuaternion();

            GameManager.instance.SpawnPlayer(id, username, position, rotation);
        }

        public static void PlayerPosition(Packet packet)
        {
            int id = packet.ReadInt();
            
            if (GameManager.players.ContainsKey(id))
            {
                Vector3 position = packet.ReadVector3();
                GameManager.players[id].transform.position = position;
            }
        }

        //public static void PlayerRotation(Packet _packet)
        //{
        //    int _id = _packet.ReadInt();
        //    Quaternion _rotation = _packet.ReadQuaternion();
        //
        //    GameManager.players[_id].transform.rotation = _rotation;
        //}

        public static void ClientsConnectionStatus(Packet packet)
        {
            bool[] connectedClients = new bool[3];

            for (int i = 0; i < connectedClients.Length; i++)
            {
                connectedClients[i] = packet.ReadBool();
                Debugger.Log("player " + i + " connection: " + connectedClients[i]);
            }
        }

        public static void EnterMultiplayerStage(Packet packet)
        {
            Debugger.Log("packet received to enter multiplayer stage");

            BaseInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.MULTIPLAYER_CLIENT_STAGE));
        }

        public static void UpdateOnPlayerData(Packet packet)
        {
            RB.Server.PlayerDataset dataset = new Server.PlayerDataset();

            dataset.playerCount = packet.ReadInt();
            dataset.listIndexes = new List<int>();
            dataset.listPositions = new List<Vector3>();
            
            for (int i = 0; i < dataset.playerCount; i++)
            {
                int playerIndex = packet.ReadInt();
                Vector3 pos = packet.ReadVector3();

                dataset.listIndexes.Add(playerIndex);
                dataset.listPositions.Add(pos);
            }

            GameInitializer.current.GetStage().UpdateClientPositions(dataset);
        }
    }
}