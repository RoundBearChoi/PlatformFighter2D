using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class Unit : MonoBehaviour
    {
        public IUpdater unitUpdater = new NoUpdate();
        public IStateController iStateController = null;
        public UnitData unitData = null;
        public AttackData attackData = null;
        
        private List<CollisionType> _listAttackingSides = new List<CollisionType>();

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void OnLateUpdate()
        {

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

        public virtual void ProcessDamage()
        {
            foreach (DamageData data in unitData.listDamageData)
            {
                unitData.health -= data.damageAmount;
            }

            unitData.listDamageData.Clear();
        }

        public virtual void SetUserInput(UserInput userInput)
        {

        }

        public virtual void InitCollisionChecker()
        {

        }

        public virtual void InitCollisionReaction()
        {

        }
    }
}