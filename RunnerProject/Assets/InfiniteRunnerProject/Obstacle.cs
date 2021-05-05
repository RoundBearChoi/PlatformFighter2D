using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Obstacle : GameElement
    {
        //public override void Init()
        //{
        //    elementData = new GameElementData(this.transform);
        //    stateController = new StateController(new Obstacle_Idle());
        //}

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