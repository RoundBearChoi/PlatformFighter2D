using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CollisionStays : Collisions
    {
        public bool IsTouchingSide()
        {
            foreach (CollisionData data in _listCollisionData)
            {
                if (data.collisionType == CollisionType.LEFT || data.collisionType == CollisionType.RIGHT)
                {
                    return true;
                }
            }

            return false;
        }
    }
}