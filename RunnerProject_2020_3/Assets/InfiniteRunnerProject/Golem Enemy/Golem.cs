using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Golem : Unit
    {
        public override void OnFixedUpdate()
        {
            unitUpdater.CustomFixedUpdate();

            //only clear after updating states
            unitData.collisionStays.Clear();
            unitData.collisionEnters.Clear();
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