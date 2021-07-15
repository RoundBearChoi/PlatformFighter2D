using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [System.Serializable]
    public class UnitData
    {
        public UnitData(Transform transform)
        {
            unitTransform = transform;
            listNextStates.Clear();
        }

        public int hp = 1;
        public bool faceRight = true;
        public Transform unitTransform = null;
        public Rigidbody2D rigidBody2D = null;
        public BoxCollider2D boxCollider2D = null;

        public CollisionStays collisionStays = new CollisionStays();
        public CollisionEnters collisionEnters = new CollisionEnters();

        public SpriteAnimations spriteAnimations = null;

        public List<State> listNextStates = new List<State>();
    }
}