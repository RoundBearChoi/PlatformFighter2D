using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct CollisionData
    {
        public CollisionData(CollisionType colType, GameObject collidingObj)
        {
            collisionType = colType;
            collidingObject = collidingObj;
        }

        public CollisionType collisionType;
        public GameObject collidingObject;
    }
}