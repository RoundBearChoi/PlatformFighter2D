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
            Runner runner = Resources.Load("Runner", typeof(Runner)) as Runner;
            CollisionDetector collisionDetector = Resources.Load("CollisionDetector", typeof(CollisionDetector)) as CollisionDetector;

            dicResources.Add(runner.GetType(), runner);
            dicResources.Add(collisionDetector.GetType(), collisionDetector);
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