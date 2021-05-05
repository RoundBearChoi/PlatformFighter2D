using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner : Unit
    {
        public CollisionDetector collisionDetector = null;
        public GameObject sampleSprite = null;

        public override void OnFixedUpdate()
        {
            if (stateController != null)
            {
                stateController.TransitionToNextState();
                stateController.UpdateState();
            }
        }

        public void SetCollisionDetector(CollisionDetector collisionDetector)
        {
            collisionDetector = Instantiate(collisionDetector);
            collisionDetector.transform.parent = this.transform;
            collisionDetector.transform.position = Vector3.zero;
            collisionDetector.transform.localRotation = Quaternion.identity;
            collisionDetector.InitBoxCollider(new Vector2(3f, 5f));

            collisionDetector.transform.localPosition += new Vector3(0f, 2.5f, 0f);
        }
    }
}