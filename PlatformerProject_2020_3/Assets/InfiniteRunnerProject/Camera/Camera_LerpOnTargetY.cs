using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Camera_LerpOnTargetY : CameraState
    {
        float _yOffsetOnPlayer = 5f;

        public Camera_LerpOnTargetY(CameraScript cameraScript)
        {
            _cameraScript = cameraScript;
        }

        public override void OnFixedUpdate()
        {
            GameObject target = _cameraScript.GetTarget();
            Camera currentCam = _cameraScript.GetCamera();

            if (target != null)
            {
                float lerpPercentage = 0.005f;

                if (currentCam.transform.position.y > target.transform.position.y + _yOffsetOnPlayer)
                {
                    lerpPercentage = 0.05f;
                }

                float camY = Mathf.Lerp(_cameraScript.GetCamera().transform.position.y, target.transform.position.y + _yOffsetOnPlayer, lerpPercentage);

                _targetPosition = new Vector3(target.transform.position.x, camY, target.transform.position.z - 5f);
            }

            _cameraScript.UpdateCameraPositionOnTarget(_targetPosition);
        }
    }
}