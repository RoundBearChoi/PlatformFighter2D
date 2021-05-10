using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController_SimpleFollow : State
    {
        private Camera _mainCam = null;
        private Unit _targetRunner = null;

        public CameraController_SimpleFollow(Unit runner, Camera maincam)
        {
            _mainCam = maincam;
            _targetRunner = runner;
        }

        public override void Update()
        {
            _mainCam.transform.position = new Vector3(_targetRunner.transform.position.x, 3f, _targetRunner.transform.position.z - 5f);
        }
    }
}