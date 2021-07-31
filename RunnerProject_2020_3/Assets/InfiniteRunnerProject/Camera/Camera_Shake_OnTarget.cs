using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Camera_Shake_OnTarget : CameraState
    {
        uint _totalShakeFrames = 0;
        float _shakeAmount = 0f;
        private Vector3 _initialPos = Vector3.zero;

        public Camera_Shake_OnTarget(uint totalShakeFrames, float shakeAmount)
        {
            _totalShakeFrames = totalShakeFrames;
            _shakeAmount = shakeAmount;
            _cameraScript = GameInitializer.current.GetStage().cameraScript;
            _initialPos = _cameraScript.GetCamera().transform.position;
        }

        public override void OnFixedUpdate()
        {
            if (_totalShakeFrames > 0)
            {
                Vector3 shakeOffset = new Vector3(Random.Range(-_shakeAmount, _shakeAmount), Random.Range(-_shakeAmount, _shakeAmount), 0f);

                GameObject target = _cameraScript.GetTarget();

                if (target != null)
                {
                    _targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + 5f, target.transform.position.z - 5f);
                }

                _targetPosition += shakeOffset;

                _cameraScript.UpdateCameraPositionOnTarget(_targetPosition);
            }
            else
            {
                _cameraScript.UpdateCameraPositionOnTarget(_initialPos);

                CameraState defaultCameraState = GameInitializer.current.GetStage().GetDefaultCameraState();
                _cameraScript.SetCameraState(defaultCameraState);
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