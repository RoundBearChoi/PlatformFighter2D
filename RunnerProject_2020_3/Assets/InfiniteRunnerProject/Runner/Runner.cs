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
                unitData.listNextStates.Add(new tempRunner_Death(this));
            }
            else if (reactionData.reactionType == CollisionReactionType.DEAL_DAMAGE)
            {
                unitData.rigidBody2D.velocity = GameInitializer.current.gameDataSO.Runner_JumpForce;
            }

            //only clear after updating states
            unitData.collisionStays.ClearList();
            unitData.collisionEnters.ClearList();
        }

        public override void OnLateUpdate()
        {
            unitUpdater.CustomLateUpdate();

            BaseMessage runnerHPUpdate = new UpdateRunnerHP_Message(unitData.hp, unitData.initialHP);
            runnerHPUpdate.Register();
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            foreach (ContactPoint2D contactPoint in collision.contacts)
            {
                CollisionType collisionType = _collisionChecker.GetCollisionType(contactPoint);
                CollisionData collisionData = new CollisionData(collisionType, collision.gameObject, contactPoint);
                unitData.collisionEnters.AddCollisionData(collisionData);
            }
        }

        public void OnCollisionStay2D(Collision2D collision)
        {
            foreach (ContactPoint2D contactPoint in collision.contacts)
            {
                CollisionType collisionType = _collisionChecker.GetCollisionType(contactPoint);
                CollisionData collisionData = new CollisionData(collisionType, collision.gameObject, contactPoint);

                unitData.collisionStays.AddCollisionData(collisionData);
            }
        }
    }
}