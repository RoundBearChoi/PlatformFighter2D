using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner : Unit
    {
        private UserInput _userInput = null;
        private ICollisionSideChecker _collisionChecker = null;
        private CollisionReaction _collisionReaction = null;

        public override void OnFixedUpdate()
        {
            unitUpdater.CustomFixedUpdate();

            spriteAnimations.OnFixedUpdate();

            CollisionReactionData reactionData = _collisionReaction.GetReactionData();

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
            else if (reactionData.reactionType == CollisionReactionType.GROUND_LAND)
            {
                //Debugger.Log("new ground collision:" + reactionData.);
                //unitData.listNextStates.Add(new Runner_NormalRun(unitData, _userInput));
            }

            //only clear after updating states
            unitData.listCollisionStays.Clear();
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

        public override void InitCollisionReaction()
        {
            _collisionReaction = new CollisionReaction(unitData);
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
                unitData.listCollisionEnters.Add(collisionData);
            }
        }

        public void OnCollisionStay2D(Collision2D collision)
        {
            unitData.listCollisionStays.Clear();

            foreach (ContactPoint2D contactPoint in collision.contacts)
            {
                CollisionType collisionType = _collisionChecker.GetCollisionType(contactPoint);
                CollisionData collisionData = new CollisionData(collisionType, collision.gameObject, contactPoint);
                unitData.listCollisionStays.Add(collisionData);
            }
        }
    }
}