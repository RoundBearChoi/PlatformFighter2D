using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class LittleRed : Unit
    {
        public LittleRed()
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