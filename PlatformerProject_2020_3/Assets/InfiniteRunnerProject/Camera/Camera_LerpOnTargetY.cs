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
            if (_cameraScript.TARGET_OBJ != null)
            {
                float lerpPercentage = 0.005f;

                if (_cameraScript.CAMERA.transform.position.y > _cameraScript.TARGET_OBJ.transform.position.y + _yOffsetOnPlayer)
                {
                    lerpPercentage = 0.05f;
                }

                float camY = Mathf.Lerp(
                    _cameraScript.CAMERA.transform.position.y,
                    _cameraScript.TARGET_OBJ.transform.position.y + _yOffsetOnPlayer,
                    lerpPercentage);

                _targetPosition = new Vector3(
                    _cameraScript.TARGET_OBJ.transform.position.x,
                    camY,
                    _cameraScript.TARGET_OBJ.transform.position.z - 5f);
            }

            _cameraScript.CAMERA.transform.position = _targetPosition;
        }
    }
}