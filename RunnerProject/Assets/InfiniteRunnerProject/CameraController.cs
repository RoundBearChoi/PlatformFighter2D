using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController : Unit
    {
        private Unit runner = null;
        private Camera mainCam = null;

        public CameraController(Unit _runner, Camera _maincam)
        {
            runner = _runner;
            mainCam = _maincam;
        }

        public override void OnFixedUpdate()
        {
            stateController.TransitionToNextState();
            stateController.UpdateState();
        }
    }
}