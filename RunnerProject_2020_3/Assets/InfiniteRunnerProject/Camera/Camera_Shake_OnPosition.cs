using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Camera_Shake_OnPosition : CameraState
    {
        uint _totalShakeFrames = 0;
        float _shakeAmount = 1f;
        Vector3 _initialPosition = Vector3.zero;

        public Camera_Shake_OnPosition(uint totalShakeFrames)
        {
            _totalShakeFrames = totalShakeFrames;
            _cameraScript = GameInitializer.current.GetStage().cameraScript;
            _initialPosition = _cameraScript.GetCamera().gameObject.transform.position;
        }

        public override void OnFixedUpdate()
        {
            if (_totalShakeFrames > 0)
            {
                Vector3 shakeOffset = new Vector3(Random.Range(-_shakeAmount, _shakeAmount), Random.Range(-_shakeAmount, _shakeAmount), 0f);

                _targetPosition = _initialPosition + shakeOffset;

                _cameraScript.UpdateCameraPositionOnTarget(_targetPosition);
            }
            else
            {
                _cameraScript.SetCameraState(new Camera_EmptyState());
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