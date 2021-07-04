using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController : Unit
    {
        public override void OnFixedUpdate()
        {
            iStateController.TransitionToNextState();
            iStateController.OnFixedUpdate();
        }
    }
}