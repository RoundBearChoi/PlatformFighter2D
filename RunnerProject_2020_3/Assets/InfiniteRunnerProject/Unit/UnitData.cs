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

        public uint hp = 1;
        public uint initialHP;
        public bool facingRight = true;
        public ComboHitCount comboHitCount = new ComboHitCount();
        public Transform unitTransform = null;
        public Rigidbody2D rigidBody2D = null;
        public BoxCollider2D boxCollider2D = null;
        public CompositeCollider2D compositeCollider2D = null;

        public Collisions collisionStays = new CollisionStays();
        public Collisions collisionEnters = new CollisionEnters();

        public ISpriteAnimations spriteAnimations = null;

        public List<UnitState> listNextStates = new List<UnitState>();
    }
}