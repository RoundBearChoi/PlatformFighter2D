using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController : Unit
    {
        private Unit runner = null;
        private Camera mainCam = null;

        public CameraController(Unit targetUnit, Camera mainCamera)
        {
            runner = targetUnit;
            mainCam = mainCamera;
        }

        public override void OnFixedUpdate()
        {
            stateController.TransitionToNextState();
            stateController.UpdateState();
        }
    }
}