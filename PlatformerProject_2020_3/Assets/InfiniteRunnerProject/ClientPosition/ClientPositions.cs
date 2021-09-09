using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    [System.Serializable]
    public class ClientPositions
    {
        [SerializeField]
        List<ClientPosition> _listPositions = null;

        public ClientPositions()
        {
            _listPositions = new List<ClientPosition>();
        }

        public ClientPosition AddClientPosition(int clientID)
        {
            ClientPosition clientPosition = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.CLIENT_POSITION) as ClientPosition);
            clientPosition.SetID(clientID);
            _listPositions.Add(clientPosition);

            clientPosition.transform.SetParent(GameInitializer.current.GetStage().transform, true);

            return clientPosition;
        }

        public ClientPosition GetClientPosition(int clientID)
        {
            foreach(ClientPosition p in _listPositions)
            {
                if (p.ID == clientID)
                {
                    return p;
                }
            }

            return null;
        }
    }
}