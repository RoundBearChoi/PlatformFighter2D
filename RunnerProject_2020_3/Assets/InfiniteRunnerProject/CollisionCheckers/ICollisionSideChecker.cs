using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public interface ICollisionSideChecker
    {
        public bool IsColliding(ContactPoint2D contactPoint);
    }
}