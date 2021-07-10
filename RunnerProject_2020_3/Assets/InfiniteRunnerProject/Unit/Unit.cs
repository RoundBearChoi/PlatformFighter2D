using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class Unit : MonoBehaviour
    {
        public BaseUpdater unitUpdater = null;
        public IStateController iStateController = null;
        public UnitData unitData = null;
        public bool deathAnimationTriggered = false;
        public bool destroy = false;

        protected ICollisionSideChecker _collisionChecker = null;

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void OnLateUpdate()
        {

        }

        public virtual void InitBoxCollider(BaseUnitCreationSpec spec)
        {
            if (spec.BoxCollider2DSize.x > 0f && spec.BoxCollider2DSize.y > 0f)
            {
                unitData.boxCollider2D = this.gameObject.AddComponent<BoxCollider2D>();
                unitData.boxCollider2D.size = spec.BoxCollider2DSize;
                unitData.boxCollider2D.offset = new Vector2(0f, spec.BoxCollider2DSize.y / 2f);

                unitData.rigidBody2D = this.gameObject.AddComponent<Rigidbody2D>();
                unitData.rigidBody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
                unitData.rigidBody2D.sharedMaterial = StaticRefs.gameData.physicsMaterial_NoFrictionNoBounce;
                unitData.rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }

        public virtual bool ProcessDamage()
        {
            bool damageTaken = false;

            foreach (DamageData data in unitData.listDamageData)
            {
                unitData.health -= data.damageAmount;
                damageTaken = true;
            }

            unitData.listDamageData.Clear();

            return damageTaken;
        }

        public virtual void InitCollisionChecker()
        {
            BoxCollider2D collider = this.gameObject.GetComponent<BoxCollider2D>();

            if (collider != null)
            {
                _collisionChecker = new CollisionChecker(collider);
            }
        }

        public virtual void RunHitReactionAnimation()
        {
            Debugger.Log("HitReaction animation not defined");
        }

        public virtual void RunDeathAnimation()
        {
            Debugger.Log("Death animation not defined");

            //destroy by default if death animation is not defined
            destroy = true;
        }
    }
}