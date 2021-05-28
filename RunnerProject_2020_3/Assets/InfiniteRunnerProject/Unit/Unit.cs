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

        public virtual void InitBoxCollider(Vector2 boxSize)
        {
            unitData.boxCollider2D = this.gameObject.AddComponent<BoxCollider2D>();
            unitData.boxCollider2D.size = boxSize;
            unitData.boxCollider2D.offset = new Vector2(0f, boxSize.y / 2f);

            unitData.rigidBody2D = this.gameObject.AddComponent<Rigidbody2D>();
            unitData.rigidBody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            unitData.rigidBody2D.sharedMaterial = StaticRefs.gameData.physicsMaterial_NoFrictionNoBounce;
            unitData.rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        public virtual void InitCollisionCheckers()
        {

        }

        public virtual void SetUserInput(UserInput userInput)
        {

        }
    }
}