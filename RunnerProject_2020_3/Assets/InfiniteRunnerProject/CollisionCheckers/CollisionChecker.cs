using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CollisionChecker : ICollisionSideChecker
    {
        private BoxCollider2D _boxCollider2D = null;

        public CollisionChecker(BoxCollider2D collider)
        {
            _boxCollider2D = collider;
        }

        public CollisionType GetCollisionType(ContactPoint2D contactPoint)
        {
            Vector2 normalizedDir = contactPoint.normal.normalized;

            float dotDown = Vector2.Dot(normalizedDir, Vector2.up);
            float dotUp = Vector2.Dot(normalizedDir, Vector2.down);
            float dotLeft = Vector2.Dot(normalizedDir, Vector2.right);
            float dotRight = Vector2.Dot(normalizedDir, Vector2.left);

            if (dotDown > 0f)
            {
                if (dotDown >= dotUp &&
                    dotDown >= dotLeft &&
                    dotDown >= dotRight)
                {
                    Debug.DrawLine(_boxCollider2D.bounds.center, contactPoint.point, Color.green, 3f);
                    return CollisionType.BOTTOM;
                }
            }

            if (dotUp > 0f)
            {
                if (dotUp >= dotDown &&
                    dotUp >= dotLeft &&
                    dotUp >= dotRight)
                {
                    Debug.DrawLine(_boxCollider2D.bounds.center, contactPoint.point, Color.yellow, 3f);
                    return CollisionType.TOP;
                }
            }

            if (dotRight > 0f)
            {
                if (dotRight >= dotUp &&
                    dotRight >= dotDown &&
                    dotRight >= dotLeft)
                {
                    Debug.DrawLine(_boxCollider2D.bounds.center, contactPoint.point, Color.red, 3f);
                    return CollisionType.FRONT;
                }
            }

            if (dotLeft > 0f)
            {
                if (dotLeft >= dotUp &&
                    dotLeft >= dotDown &&
                    dotLeft >= dotRight)
                {
                    Debug.DrawLine(_boxCollider2D.bounds.center, contactPoint.point, Color.magenta, 3f);
                    return CollisionType.BACK;
                }
            }

            return CollisionType.NONE;
        }
    }
}