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
            unitUpdater.CustomUpdate();

            foreach (SpriteAnimation ani in listSpriteAnimations)
            {
                ani.OnFixedUpdate();
            }

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
                Debugger.Log("new ground collision");
                unitData.listNextStates.Add(new Runner_NormalRun(unitData, _userInput));
            }

            unitData.listCollisionData.Clear();
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            foreach(ContactPoint2D contactPoint in collision.contacts)
            {
                CollisionType collisionType = _collisionChecker.GetCollisionType(contactPoint);
                CollisionData collisionData = new CollisionData(collisionType, collision.gameObject);
                unitData.listCollisionData.Add(collisionData);
            }
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
    }
}