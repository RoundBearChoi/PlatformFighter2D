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

        public override void SetHashString()
        {

        }

        public override void OnFixedUpdate()
        {
            _mainCam.transform.position = new Vector3(
                _targetRunner.transform.position.x,
                _targetRunner.transform.position.y + 2.5f,
                _targetRunner.transform.position.z - 5f);
        }
    }
}