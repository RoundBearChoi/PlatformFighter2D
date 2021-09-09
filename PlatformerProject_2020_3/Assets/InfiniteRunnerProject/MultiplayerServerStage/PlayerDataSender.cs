using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    [System.Serializable]
    public class PlayerDataSender
    {
        [SerializeField]
        List<ServerPlayer> _playersOnServer = null;

        public PlayerDataSender()
        {
            _playersOnServer = new List<ServerPlayer>();
        }

        public void AddUnit(Unit unit, int index)
        {
            _playersOnServer.Add(new ServerPlayer(unit, index));
        }

        public void OnFixedUpdate()
        {
            foreach(ServerPlayer player in _playersOnServer)
            {
                player.OnFixedUpdate();
            }

            PlayerDataset dataset = new PlayerDataset();
            dataset.playerCount = _playersOnServer.Count;

            dataset.listIDs = new List<int>();
            dataset.listPositions = new List<Vector3>();

            for (int i = 0; i < _playersOnServer.Count; i++)
            {
                dataset.listIDs.Add(_playersOnServer[i].GetIndex());
                dataset.listPositions.Add(_playersOnServer[i].GetPosition());
            }

            RB.Server.BaseNetworkControl.CURRENT.serverSend.SendPlayerData(dataset);
        }
    }
}