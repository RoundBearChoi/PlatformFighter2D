using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [System.Serializable]
    public class UnitPhysicsData
    {
        public Rigidbody2D rigidBody2D = null;
        public BoxCollider2D boxCollider2D = null;
        public CompositeCollider2D compositeCollider2D = null;

        public AirControl airControl = new AirControl();
        public Collisions collisionStays = new CollisionStays();
        public Collisions collisionEnters = new CollisionEnters();
    }
}