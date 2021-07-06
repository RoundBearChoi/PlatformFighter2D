using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class GameResources<KeyType>
    {
        protected Dictionary<KeyType, Object> dicResources = new Dictionary<KeyType, Object>();

        public virtual void LoadObj<ObjType>(KeyType keyType, string objName)
        {
            Object createdObj = Resources.Load(objName, typeof(ObjType));
            dicResources.Add(keyType, createdObj);
        }

        public virtual Object GetObj(KeyType keyType)
        {
            if (dicResources.ContainsKey(keyType))
            {
                return dicResources[keyType];
            }
            else
            {
                return null;
            }
        }
    }
}