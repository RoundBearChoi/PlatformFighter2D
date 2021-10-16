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

                GameObject target = _cameraScript.GetTarget();

                if (target != null)
                {
                    _targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + BaseInitializer.current.fighterDataSO.CameraYOffset, BaseInitializer.current.fighterDataSO.Camera_z);
                }

                _targetPosition += shakeOffset;

                _cameraScript.UpdateCameraPositionOnTarget(_targetPosition);
            }
        }
    }
}