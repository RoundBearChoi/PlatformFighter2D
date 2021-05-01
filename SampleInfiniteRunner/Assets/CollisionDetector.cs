using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CollisionDetector : MonoBehaviour
    {
        public BoxCollider2D collider2D_box = null;
        public CircleCollider2D collider2d_circle = null;

        public void InitBoxCollider(Vector2 boxSize)
        {
            collider2D_box = this.gameObject.AddComponent<BoxCollider2D>();
            collider2D_box.size = boxSize;
        }

        public void InitCirlceCollider()
        {

        }
    }
}