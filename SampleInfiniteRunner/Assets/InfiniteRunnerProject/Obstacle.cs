using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Obstacle : GameElement
    {
        public override void Init()
        {
            stateController = new StateController(new Obstacle_Idle());
            elementData = new GameElementData(this.transform);
        }

        public override void OnFixedUpdate()
        {
            if (stateController != null)
            {
                stateController.TransitionToNextState(elementData);
                stateController.UpdateState(elementData);
            }
        }
    }
}