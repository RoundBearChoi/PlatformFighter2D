using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RB
{
    public class ConnectedUI : UIElement
    {
        [SerializeField]
        HorizontalLayoutGroup _horizontalGroup = null;

        [SerializeField]
        List<ConnectedPlayerInfo> _connectedPlayers = null;

        public override void InitElement()
        {
            _connectedPlayers = new List<ConnectedPlayerInfo>();

            AddConnectedPlayerInfo("PLAYER", true);
        }

        public override void OnLateUpdate()
        {
            if (RB.Client.ClientManager.CURRENT != null)
            {
                OnClientLobby();
            }

            if (RB.Server.ServerManager.CURRENT != null)
            {
                OnServerLobby();
            }
        }

        void OnClientLobby()
        {
            RB.Client.ClientConnection[] connections = RB.Client.ClientManager.CURRENT.GetClientConnectionStatus();

            int totalConnected = 0;

            foreach (RB.Client.ClientConnection c in connections)
            {
                if (c.mConnected)
                {
                    totalConnected++;
                }
            }

            if (_connectedPlayers.Count - 1 != totalConnected)
            {
                UpdateOnConnections(connections);
            }
        }

        void OnServerLobby()
        {
            if (RB.Server.ServerManager.CURRENT.serverController.clients.CLIENTS_COUNT != _connectedPlayers.Count - 1)
            {
                RB.Server.ClientData[] clients = RB.Server.ServerManager.CURRENT.serverController.clients.GetAllClients();
                RB.Client.ClientConnection[] connections = RB.Client.ClientConnection.GetData(clients);
                UpdateOnConnections(connections);
            }
        }

        void UpdateOnConnections(RB.Client.ClientConnection[] connections)
        {
            Debugger.Log("updating connected clients ui");

            //destroy all
            foreach (ConnectedPlayerInfo connected in _connectedPlayers)
            {
                Destroy(connected.gameObject);
            }

            _connectedPlayers.Clear();

            //re-add
            AddConnectedPlayerInfo("SERVER", true);

            for (int i = 0; i < connections.Length; i++)
            {
                if (connections[i].mConnected)
                {
                    AddConnectedPlayerInfo("PLAYER " + connections[i].mIndex.ToString(), false);
                }
            }
        }

        void AddConnectedPlayerInfo(string playerName, bool isServer)
        {
            ConnectedPlayerInfo connectedPlayerInfo = Instantiate(ResourceLoader.etcLoader.GetObj(etcType.CONNECTED_PLAYER_INFO)) as ConnectedPlayerInfo;
            connectedPlayerInfo.transform.SetParent(_horizontalGroup.transform, false);
            connectedPlayerInfo.SetPlayerName(playerName);
            connectedPlayerInfo.ToggleServerIndicator(isServer);
            _connectedPlayers.Add(connectedPlayerInfo);
        }
    }
}