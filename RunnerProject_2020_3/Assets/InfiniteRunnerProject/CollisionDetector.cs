using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CollisionDetector : MonoBehaviour
    {
        public BoxCollider2D collider2D_box = null;
        public CircleCollider2D collider2d_circle = null;
        public Rigidbody2D rigidBody2D = null;
        public List<GameObject> listCollidedGameObjects = new List<GameObject>();

        public void InitBoxCollider(Vector2 boxSize)
        {
            collider2D_box = this.gameObject.AddComponent<BoxCollider2D>();
            collider2D_box.size = boxSize;
            collider2D_box.isTrigger = true;

            if (rigidBody2D == null)
            {
                rigidBody2D = this.gameObject.AddComponent<Rigidbody2D>();
                rigidBody2D.gravityScale = 0f;
            }
        }

        public void InitCirlceCollider()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            listCollidedGameObjects.Add(other.gameObject);
            Debugger.Log("2D trigger detected against: " + other.gameObject.name);
        }
    }
}