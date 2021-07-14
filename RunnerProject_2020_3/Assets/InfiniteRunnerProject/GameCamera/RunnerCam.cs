using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerCam : Unit
    {
        public static Camera gameCam = null;
        public static Unit current = null;

        public RunnerCam()
        {
            unitMessageHandler = new CameraMessageHandler(this);
        }

        public override void OnFixedUpdate()
        {
            iStateController.TransitionToNextState();
            iStateController.OnFixedUpdate();
        }
    }
}