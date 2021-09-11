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
            unit.clientIndex = index;
            _playersOnServer.Add(new ServerPlayer(unit, index));
        }

        public void SendPlayerUnitTypesToAllClients()
        {
            PlayerDataset<UnitType> dataset = new PlayerDataset<UnitType>();
            dataset.playerCount = _playersOnServer.Count;

            dataset.listIDs = new List<int>();
            dataset.listData = new List<UnitType>();

            for (int i = 0; i < _playersOnServer.Count; i++)
            {
                dataset.listIDs.Add(_playersOnServer[i].GetIndex());
                dataset.listData.Add(_playersOnServer[i].GetUnit().unitType);
            }

            RB.Server.BaseNetworkControl.CURRENT.serverSend.SendPlayerUnitTypes(dataset);
        }

        public void OnFixedUpdate()
        {
            foreach(ServerPlayer player in _playersOnServer)
            {
                player.OnFixedUpdate();
            }

            PlayerDataset<PositionAndDirection> dataset = new PlayerDataset<PositionAndDirection>();
            dataset.playerCount = _playersOnServer.Count;

            dataset.listIDs = new List<int>();
            dataset.listData = new List<PositionAndDirection>();

            for (int i = 0; i < _playersOnServer.Count; i++)
            {
                dataset.listIDs.Add(_playersOnServer[i].GetIndex());

                PositionAndDirection positionAndDirection = new PositionAndDirection(_playersOnServer[i].GetPosition(), _playersOnServer[i].IsFacingRight());

                dataset.listData.Add(positionAndDirection);
            }

            RB.Server.BaseNetworkControl.CURRENT.serverSend.SendPlayerPositions(dataset);
        }
    }
}