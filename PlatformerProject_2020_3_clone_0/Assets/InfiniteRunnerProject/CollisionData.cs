using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct CollisionData
    {
        public CollisionData(CollisionType type, GameObject collidingObj, ContactPoint2D contact)
        {
            collisionType = type;
            collidingObject = collidingObj;
            contactPoint = contact;
        }

        public CollisionType collisionType;
        public GameObject collidingObject;
        public ContactPoint2D contactPoint;
    }
}