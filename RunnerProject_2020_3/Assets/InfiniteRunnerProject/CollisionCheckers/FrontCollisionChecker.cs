using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FrontCollisionChecker : ICollisionSideChecker
    {
        private BoxCollider2D _collider2D = null;

        public FrontCollisionChecker(BoxCollider2D collider2D)
        {
            _collider2D = collider2D;
        }

        public bool IsColliding(ContactPoint2D contactPoint)
        {
            Vector2 topRight = new Vector3(
                _collider2D.bounds.center.x + _collider2D.bounds.extents.x,
                _collider2D.bounds.center.y + _collider2D.bounds.extents.y + 3f);

            Vector2 down = contactPoint.point - topRight;
            down.Normalize();

            float dot = Vector2.Dot(down, Vector2.down);

            if (dot >= 0.999f && dot <= 1f)
            {
                if (contactPoint.normal.y <= 0f)
                {
                    Debug.DrawLine(topRight, contactPoint.point, Color.green, 1f);
                }
            }

            return false;
        }
    }
}