using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ResourceLoader : MonoBehaviour
    {
        public Dictionary<System.Type, Object> dicResources = new Dictionary<System.Type, Object>();

        private void Start()
        {
            Runner obj = Resources.Load("Runner", typeof(Runner)) as Runner;
            dicResources.Add(obj.GetType(), obj);
        }

        public Object Get(System.Type _type)
        {
            if (dicResources.ContainsKey(_type))
            {
                return dicResources[_type];
            }
            else
            {
                return null;
            }
        }
    }
}