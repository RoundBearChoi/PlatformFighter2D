using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController : Unit
    {
        public override void OnFixedUpdate()
        {
            stateController.TransitionToNextState();
            stateController.OnFixedUpdate();
        }
    }
}