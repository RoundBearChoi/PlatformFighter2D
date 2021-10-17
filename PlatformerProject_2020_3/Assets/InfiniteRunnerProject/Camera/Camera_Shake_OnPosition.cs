using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Camera_Shake_OnPosition : CameraState
    {
        uint _totalShakeFrames = 0;
        float _shakeAmount = 0f;
        Vector3 _initialPosition = Vector3.zero;

        public Camera_Shake_OnPosition(CameraScript cameraScript, uint totalShakeFrames, float shakeAmount)
        {
            _cameraScript = cameraScript;

            _totalShakeFrames = totalShakeFrames;
            _shakeAmount = shakeAmount;
            _initialPosition = _cameraScript.CAMERA.gameObject.transform.position;
        }

        public override void OnFixedUpdate()
        {

        }

        public override void OnUpdate()
        {
            if (_totalShakeFrames > 0)
            {
                Vector3 shakeOffset = new Vector3(Random.Range(-_shakeAmount, _shakeAmount), Random.Range(-_shakeAmount, _shakeAmount), 0f);

                _targetPosition = _initialPosition + shakeOffset;

                _cameraScript.CAMERA.transform.position = _targetPosition;
            }
            else
            {
                _cameraScript.SetCameraState(defaultState, false);
            }
        }

        public override void OnLateUpdate()
        {
            if (_totalShakeFrames > 0)
            {
                _totalShakeFrames--;
            }
        }
    }
}