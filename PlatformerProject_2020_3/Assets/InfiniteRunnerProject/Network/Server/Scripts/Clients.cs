using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Server
{
    [System.Serializable]
    public class Clients
    {
        private static int _connectCount = 0;

        [SerializeField]
        private List<ClientData> _listClientData = null;

        public Clients()
        {
            _listClientData = new List<ClientData>();


        }

        public int CLIENTS_COUNT
        {
            get
            {
                return _listClientData.Count;
            }
        }

        public bool AddClient(System.Net.Sockets.TcpClient tcpClient)
        {
            try
            {
                ClientData data = new ClientData(_connectCount);
                _connectCount++;

                if (_connectCount >= int.MaxValue)
                {
                    _connectCount = 0;
                }

                _listClientData.Add(data);
                data.tcp.Connect(tcpClient);
                
                return true;
            }
            catch (System.Exception e)
            {
                Debugger.Log(e);
            }

            return false;
        }

        public void RemoveClient(ClientData data)
        {
            if (_listClientData.Contains(data))
            {
                _listClientData.Remove(data);
            }
        }

        public ClientData GetClientData(int clientID)
        {
            foreach(ClientData data in _listClientData)
            {
                if (data.tcp.ID == clientID)
                {
                    return data;
                }
            }

            return null;
        }

        public ClientData[] GetAllClients()
        {
            ClientData[] arr = new ClientData[_listClientData.Count];

            for (int i = 0; i < _listClientData.Count; i++)
            {
                arr[i] = _listClientData[i];
            }

            return arr;
        }
    }
}