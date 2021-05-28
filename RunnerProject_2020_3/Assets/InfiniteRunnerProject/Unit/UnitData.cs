using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UnitData
    {
        public UnitData(Transform transform)
        {
            unitTransform = transform;
            listCollisionData.Clear();
            listNextStates.Clear();
        }

        public uint health = 1;
        public Transform unitTransform = null;
        public Rigidbody2D rigidBody2D = null;
        public BoxCollider2D boxCollider2D = null;

        public bool destroy = false;

        public List<CollisionData> listCollisionData = new List<CollisionData>();
        public List<State> listNextStates = new List<State>();

        public Ground currentGround = null;
    }
}