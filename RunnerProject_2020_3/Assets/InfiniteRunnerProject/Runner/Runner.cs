using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner : Unit
    {
        public Runner()
        {
            messageHandler = new RunnerMessageHandler(this);
        }

        public override void OnUpdate()
        {
            unitUpdater.CustomUpdate();
        }

        public override void OnFixedUpdate()
        {
            unitUpdater.CustomFixedUpdate();

            CollisionReaction reactionData = unitData.collisionEnters.GetReactionData();

            if (reactionData.reactionType == CollisionReactionType.TAKE_DAMAGE)
            {
                Debugger.Log("take damage!");
                unitData.listNextStates.Add(new Runner_Death(this));
            }
            else if (reactionData.reactionType == CollisionReactionType.DEAL_DAMAGE)
            {
                //needs to be put somewhere else
                unitData.rigidBody2D.velocity = GameInitializer.current.gameDataSO.Runner_JumpUp_StartForce;
            }

            //only clear after updating states
            unitData.collisionStays.Clear();
            unitData.collisionEnters.Clear();
        }

        public override void OnLateUpdate()
        {
            unitUpdater.CustomLateUpdate();
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
            foreach (ContactPoint2D contactPoint in collision.contacts)
            {
                CollisionType collisionType = _collisionChecker.GetCollisionType(contactPoint);
                CollisionData collisionData = new CollisionData(collisionType, collision.gameObject, contactPoint);

                unitData.collisionStays.AddCollisionStay(collisionData);
            }
        }
    }
}