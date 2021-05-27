using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct CollisionData
    {
        public CollisionData(CollisionType colType)
        {
            collisionType = colType;
        }

        public CollisionType collisionType;
    }
}