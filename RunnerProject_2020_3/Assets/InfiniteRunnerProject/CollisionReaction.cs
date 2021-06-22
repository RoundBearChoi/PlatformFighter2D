using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public struct CollisionReaction
    {
        public CollisionReaction(CollisionReactionType collisionReactionType, Unit targetCollidingUnit)
        {
            reactionType = collisionReactionType;
            collidingUnit = targetCollidingUnit;
        }

        public CollisionReactionType reactionType;
        public Unit collidingUnit;
    }
}