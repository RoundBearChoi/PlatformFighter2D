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
    }
}