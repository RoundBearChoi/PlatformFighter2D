using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class Unit : MonoBehaviour
    {
        public BaseUpdater unitUpdater = null;
        public UnitType unitType = UnitType.NONE;
        public IStateController<UnitState> iStateController = null;
        public UnitData unitData = new UnitData();
        public bool deathAnimationTriggered = false;
        public bool destroy = false;
        public BaseMessageHandler messageHandler = null;
        public EnemyHPBar hpBar = null;
        public int clientIndex = 0;
        public bool isDummy = false;

        protected ICollisionSideChecker _collisionChecker = null;

        [Header("Debug")]
        [SerializeField] protected UserInput _userInput = null;
        
        public UserInput USER_INPUT
        {
            get
            {
                return _userInput;
            }
        }

        public void SetFighterInput(UserInput userInput)
        {
            _userInput = userInput;
        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void OnLateUpdate()
        {

        }

        public virtual void HandleMessages()
        {

        }

        public virtual void InitBoxCollider(UnitCreationSpec spec)
        {
            if (spec.BoxCollider2DSize.x > 0f && spec.BoxCollider2DSize.y > 0f)
            {
                unitData.boxCollider2D = this.gameObject.AddComponent<BoxCollider2D>();
                unitData.boxCollider2D.size = spec.BoxCollider2DSize;
                unitData.boxCollider2D.offset = new Vector2(0f, spec.BoxCollider2DSize.y / 2f);

                unitData.rigidBody2D = this.gameObject.AddComponent<Rigidbody2D>();
                unitData.rigidBody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
                unitData.rigidBody2D.sharedMaterial = BaseInitializer.current.runnerDataSO.physicsMaterial_NoFrictionNoBounce;
                unitData.rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }

        public virtual void InitCollisionChecker()
        {
            BoxCollider2D collider = this.gameObject.GetComponent<BoxCollider2D>();

            if (collider != null)
            {
                _collisionChecker = new CollisionChecker(collider);
            }
        }
    }
}