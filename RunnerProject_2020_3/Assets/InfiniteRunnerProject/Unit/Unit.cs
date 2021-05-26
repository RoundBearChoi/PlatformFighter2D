using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class Unit : MonoBehaviour
    {
        public StateController stateController = null;
        public UnitData unitData = null;
        public CollisionDetector collisionDetector = null;

        public List<SpriteAnimation> listSpriteAnimations = new List<SpriteAnimation>();
        public IUpdater unitUpdater = null;

        private BoxCollider2D _boxCollider2D = null;
        private Rigidbody2D _rigidBody2D = null;

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void MatchAnimationToState()
        {
            foreach (SpriteAnimation spriteAni in listSpriteAnimations)
            {
                int n = spriteAni.animationHash.CompareTo(stateController.currentState.GetAnimationHash());

                if (n == 0)
                {
                    spriteAni.gameObject.SetActive(true);
                }
                else
                {
                    spriteAni.gameObject.SetActive(false);
                }
            }
        }

        public virtual void SetUpdater(IUpdater updater)
        {
            unitUpdater = updater;
        }

        public virtual void OnCollision()
        {

        }

        public virtual void InitBoxCollider(Vector2 boxSize)
        {
            _boxCollider2D = this.gameObject.AddComponent<BoxCollider2D>();
            _boxCollider2D.size = boxSize;
            //_boxCollider2D.isTrigger = true;

            //if (_rigidBody2D == null)
            //{
                _rigidBody2D = this.gameObject.AddComponent<Rigidbody2D>();
                //_rigidBody2D.gravityScale = 0f;
            //}
        }
    }
}