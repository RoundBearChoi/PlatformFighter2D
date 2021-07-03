using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner : Unit
    {
        private UserInput _userInput = null;
        private ICollisionSideChecker _collisionChecker = null;

        public override void OnFixedUpdate()
        {
            unitUpdater.CustomFixedUpdate();

            unitData.spriteAnimations.OnFixedUpdate();

            CollisionReaction reactionData = unitData.collisionEnters.GetReactionData();

            if (reactionData.reactionType == CollisionReactionType.TAKE_DAMAGE)
            {
                Debugger.Log("take damage!");
                unitData.listNextStates.Add(new Runner_Death(unitData));
            }
            else if (reactionData.reactionType == CollisionReactionType.DEAL_DAMAGE)
            {
                reactionData.collidingUnit.unitData.listDamageData.Add(new DamageData(1f, this));
                unitData.rigidBody2D.velocity = StaticRefs.gameData.Runner_JumpUp_StartForce;
            }

            //only clear after updating states
            unitData.collisionStays.Clear();
            unitData.collisionEnters.Clear();
        }

        public override void OnLateUpdate()
        {
            unitUpdater.CustomLateUpdate();
        }

        public override void InitCollisionChecker()
        {
            BoxCollider2D collider = this.gameObject.GetComponent<BoxCollider2D>();
            _collisionChecker = new CollisionChecker(collider);
        }

        public override void SetUserInput(UserInput userInput)
        {
            _userInput = userInput;
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            foreach (ContactPoint2D contactPoint in collision.contacts)
            {
                CollisionType collisionType = _collisionChecker.GetCollisionType(contactPoint);
                CollisionData collisionData = new CollisionData(collisionType, collision.gameObject, contactPoint);
                unitData.collisionEnters.Add(collisionData);
            }
        }

        public void OnCollisionStay2D(Collision2D collision)
        {
            unitData.collisionStays.Clear();

            foreach (ContactPoint2D contactPoint in collision.contacts)
            {
                CollisionType collisionType = _collisionChecker.GetCollisionType(contactPoint);
                CollisionData collisionData = new CollisionData(collisionType, collision.gameObject, contactPoint);

                unitData.collisionStays.AddCollisionStay(collisionData);
            }
        }
    }
}