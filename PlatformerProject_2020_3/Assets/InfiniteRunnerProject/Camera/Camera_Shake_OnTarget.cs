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

        public Camera_Shake_OnTarget(CameraScript cameraScript, uint totalShakeFrames, float shakeAmount)
        {
            _cameraScript = cameraScript;
            _totalShakeFrames = totalShakeFrames;
            _shakeAmount = shakeAmount;
        }

        public override void OnFixedUpdate()
        {
            if (_totalShakeFrames <= 0)
            {
                _cameraScript.SetCameraState(defaultState, false);
            }
        }

        public override void OnLateUpdate()
        {
            if (_totalShakeFrames > 0)
            {
                _totalShakeFrames--;

                float xShake = _shakeAmount;
                float yShake = _shakeAmount;

                if (Random.Range(0f, 1f) > 0.5f)
                {
                    xShake *= -1f;
                }

                if (Random.Range(0f, 1f) > 0.5f)
                {
                    yShake *= -1f;
                }

                Vector3 shakeOffset = new Vector3(xShake, yShake, 0f);

                if (_cameraScript.TARGET_OBJ != null)
                {
                    _targetPosition = new Vector3(
                        _cameraScript.TARGET_OBJ.transform.position.x,
                        _cameraScript.TARGET_OBJ.transform.position.y + BaseInitializer.CURRENT.fighterDataSO.CameraYOffset,
                        BaseInitializer.CURRENT.fighterDataSO.Camera_z);
                }

                _targetPosition += shakeOffset;

                _cameraScript.UpdateCameraPositionOnTarget(_targetPosition);
            }
        }
    }
}