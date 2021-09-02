using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public interface ICollisionSideChecker
    {
        public CollisionType GetCollisionType(ContactPoint2D contactPoint);
    }
}