using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    [System.Serializable]
    public class PlayerDataSender
    {
        [SerializeField]
        List<PlayerInServer> _playersInServer = null;

        public PlayerDataSender()
        {
            _playersInServer = new List<PlayerInServer>();
        }

        public void AddUnit(Unit unit, int index)
        {
            unit.clientIndex = index;
            _playersInServer.Add(new PlayerInServer(unit, index));
        }

        public void SendPlayerUnitTypesToAllClients()
        {
            PlayerDataset<UnitType> dataset = new PlayerDataset<UnitType>();
            dataset.playerCount = _playersInServer.Count;

            dataset.listIDs = new List<int>();
            dataset.listData = new List<UnitType>();

            for (int i = 0; i < _playersInServer.Count; i++)
            {
                dataset.listIDs.Add(_playersInServer[i].GetIndex());
                dataset.listData.Add(_playersInServer[i].GetUnit().unitType);
            }

            RB.Server.ServerManager.CURRENT.serverSend.SendPlayerUnitTypes(dataset);
        }

        public void Send()
        {
            foreach(PlayerInServer player in _playersInServer)
            {
                player.OnFixedUpdate();
            }

            PlayerDataset<PositionAndDirection> dataset = new PlayerDataset<PositionAndDirection>();
            dataset.playerCount = _playersInServer.Count;

            dataset.listIDs = new List<int>();
            dataset.listData = new List<PositionAndDirection>();

            for (int i = 0; i < _playersInServer.Count; i++)
            {
                dataset.listIDs.Add(_playersInServer[i].GetIndex());

                PositionAndDirection positionAndDirection = new PositionAndDirection(_playersInServer[i].GetPosition(), _playersInServer[i].IsFacingRight());

                dataset.listData.Add(positionAndDirection);
            }

            RB.Server.ServerManager.CURRENT.serverSend.SendPlayerPositions(dataset);
        }
    }
}