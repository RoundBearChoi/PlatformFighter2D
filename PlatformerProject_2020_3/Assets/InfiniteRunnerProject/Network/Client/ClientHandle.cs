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
            ClientManager.CURRENT.clientController.myId = myId;
            ClientSend.WelcomeReceived();

            int port = ((IPEndPoint)ClientManager.CURRENT.clientController.clientTCP.SOCKET.Client.LocalEndPoint).Port;
            ClientManager.CURRENT.clientController.clientUDP.Connect(port);

            BaseMessage connectedMessage = new Message_ConnectedToServer();
            connectedMessage.Register();
        }

        public static void ClientsConnectionStatus(Packet packet)
        {
            Debugger.Log("--- clients connection status ---");

            bool[] connectedClients = new bool[3];

            ClientConnection[] connections = new[] {
                new ClientConnection (999, false),
                new ClientConnection (999, false),
                new ClientConnection (999, false),};

            for (int i = 0; i < connectedClients.Length; i++)
            {
                connectedClients[i] = packet.ReadBool();
                int id = packet.ReadInt();

                Debugger.Log("player " + i + " connection: " + connectedClients[i] + "(ID: " + id + ")");

                connections[i].mConnected = connectedClients[i];
                connections[i].mIndex = id;
            }

            ClientManager.CURRENT.UpdateClientConnectionStatus(connections);
        }

        public static void EnterMultiplayerStage(Packet packet)
        {
            Debugger.Log("packet received to enter multiplayer stage");

            BaseInitializer.current.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.MULTIPLAYER_CLIENT_STAGE));
        }

        public static void InitOnPlayerUnitTypes(Packet packet)
        {
            Debugger.Log("player unit types received");

            RB.Server.PlayerDataset<UnitType> dataset = new Server.PlayerDataset<UnitType>();

            dataset.playerCount = packet.ReadInt();
            dataset.listIDs = new List<int>();
            dataset.listData = new List<UnitType>();

            for (int i = 0; i < dataset.playerCount; i++)
            {
                int playerIndex = packet.ReadInt();
                int unitType = packet.ReadInt();

                dataset.listIDs.Add(playerIndex);
                dataset.listData.Add((UnitType)unitType);
            }

            BaseInitializer.current.GetStage().UpdateClientUnitTypes(dataset);
        }

        public static void UpdateOnPlayerPositions(Packet packet)
        {
            RB.Server.PlayerDataset<RB.Server.PositionAndDirection> dataset = new Server.PlayerDataset<RB.Server.PositionAndDirection>();

            dataset.playerCount = packet.ReadInt();
            dataset.listIDs = new List<int>();
            dataset.listData = new List<RB.Server.PositionAndDirection>();
            
            for (int i = 0; i < dataset.playerCount; i++)
            {
                int playerIndex = packet.ReadInt();
                Vector3 pos = packet.ReadVector3();
                bool facingRight = packet.ReadBool();

                dataset.listIDs.Add(playerIndex);

                RB.Server.PositionAndDirection positionAndDirection = new RB.Server.PositionAndDirection(pos, facingRight);
                dataset.listData.Add(positionAndDirection);
            }

            BaseInitializer.current.GetStage().SetTargetClientPosition(dataset);
        }

        public static void UpdateOnPlayerSpriteType(Packet packet)
        {
            int index = packet.ReadInt();
            int spriteType = packet.ReadInt();
            SpriteType st = (SpriteType)spriteType;

            Debugger.Log("player " + index + " sprite type received: " + " " + st.ToString());

            BaseInitializer.current.GetStage().UpdateClientSprite(index, st);
        }
    }
}