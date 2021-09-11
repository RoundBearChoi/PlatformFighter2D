using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB.Client
{
    [System.Serializable]
    public class ClientObjects
    {
        [SerializeField]
        List<ClientObject> _listClientObjects = null;

        public ClientObjects()
        {
            _listClientObjects = new List<ClientObject>();
        }

        public ClientObject AddClientObj(int clientID)
        {
            ClientObject clientObject = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.CLIENT_OBJECT) as ClientObject);
            clientObject.SetID(clientID);
            _listClientObjects.Add(clientObject);

            clientObject.transform.SetParent(GameInitializer.current.GetStage().transform, true);

            return clientObject;
        }

        public ClientObject GetClientObj(int clientID)
        {
            foreach(ClientObject p in _listClientObjects)
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