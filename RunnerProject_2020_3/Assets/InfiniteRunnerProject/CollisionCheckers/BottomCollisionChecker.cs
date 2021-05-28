using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class BottomCollisionChecker : ICollisionSideChecker
    {
        private BoxCollider2D _collider2D = null;

        public BottomCollisionChecker(BoxCollider2D collider2D)
        {
            _collider2D = collider2D;
        }

        public bool IsColliding(ContactPoint2D contactPoint)
        {
            Vector2 bottomLeft = new Vector3(
                _collider2D.bounds.center.x - _collider2D.bounds.extents.x - 3f,
                _collider2D.bounds.center.y - _collider2D.bounds.extents.y);

            Vector2 right = contactPoint.point - bottomLeft;
            Vector2 rightNormalized = right.normalized;

            if (Mathf.Abs(rightNormalized.y) < 0.01f)
            {
                Debug.DrawLine(bottomLeft, contactPoint.point, Color.green, 1f);
                return true;
            }

            //float dot = Vector2.Dot(rightNormalized, Vector2.right);
            //
            //if (dot >= 0.999f && dot <= 1f)
            //{
            //    Debug.DrawLine(bottomLeft, contactPoint.point, Color.green, 1f);
            //    return true;
            //}

            return false;
        }
    }
}