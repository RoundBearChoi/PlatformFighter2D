using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController : Unit
    {
        public static Camera gameCam = null;

        public override void OnFixedUpdate()
        {
            iStateController.TransitionToNextState();
            iStateController.OnFixedUpdate();
        }
    }
}