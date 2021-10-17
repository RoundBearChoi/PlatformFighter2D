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

        public void OnUpdate()
        {
            foreach (ClientObject obj in _listClientObjects)
            {
                obj.UpdatePosition();
            }
        }

        public void OnFixedUpdate()
        {
            foreach(ClientObject obj in _listClientObjects)
            {
                obj.FixedUpdatePosition();

                SpriteAnimation ani = obj.GetCurrentAnimation();

                if (ani != null)
                {
                    ani.UpdateSpriteIndex();
                    ani.UpdateSpriteOnIndex();
                }
            }
        }

        public ClientObject AddClientObj(int clientID)
        {
            ClientObject clientObject = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.CLIENT_OBJECT) as ClientObject);
            clientObject.SetID(clientID);
            _listClientObjects.Add(clientObject);

            clientObject.transform.SetParent(BaseInitializer.current.STAGE.transform, true);

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

        public void SetSpriteAnimation(int index, SpriteType spriteType)
        {
            foreach (ClientObject p in _listClientObjects)
            {
                if (p.ID == index)
                {
                    p.SetAnimation(spriteType);
                }
            }
        }
    }
}