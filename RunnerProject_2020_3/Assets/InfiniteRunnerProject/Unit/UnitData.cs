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
            listCollisionEnters.Clear();
            listNextStates.Clear();
            listDamageData.Clear();
        }

        public float health = 1f;
        public Transform unitTransform = null;
        public Rigidbody2D rigidBody2D = null;
        public BoxCollider2D boxCollider2D = null;

        public List<CollisionData> listCollisionEnters = new List<CollisionData>();
        public List<CollisionData> listCollisionStays = new List<CollisionData>();
        public List<State> listNextStates = new List<State>();
        public List<DamageData> listDamageData = new List<DamageData>();

        public Ground currentGround = null;
    }
}