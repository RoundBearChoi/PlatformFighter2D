using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController
    {
        private Runner runner = null;
        private Camera mainCam = null;

        public CameraController(Runner _runner, Camera _maincam)
        {
            runner = _runner;
            mainCam = _maincam;
        }

        public void OnFixedUpdate()
        {
            mainCam.transform.position = new Vector3(runner.transform.position.x, 0f, runner.transform.position.z - 5f);
        }
    }
}