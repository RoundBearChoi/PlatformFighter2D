using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Runner : Unit
    {
        public GameObject sampleSprite = null;

        public override void OnFixedUpdate()
        {
            //if (stateController != null)
            //{
            //    stateController.TransitionToNextState();
            //    stateController.UpdateState();
            //}

            if (unitUpdater != null)
            {
                unitUpdater.CustomUpdate();
            }

            foreach(SpriteAnimation ani in listSpriteAnimations)
            {
                ani.OnFixedUpdate();
            }
        }

        public override void OnCollision()
        {
            Debugger.Log("runner collision");

            if (unitData.health > 0)
            {
                unitData.health--;
                stateController.currentState.nextState = StateFactory.Create_Runner_Death_Up(unitData);
            }
        }
    }
}