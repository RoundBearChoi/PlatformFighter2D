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
            _cameraScript = BaseInitializer.current.GetStage().cameraScript;
            //_initialPos = _cameraScript.GetCamera().transform.position;
        }

        public override void OnFixedUpdate()
        {
            if (_totalShakeFrames <= 0)
            {
                //_cameraScript.UpdateCameraPositionOnTarget(_initialPos);

                CameraState defaultCameraState = BaseInitializer.current.GetStage().GetDefaultCameraState();
                _cameraScript.SetCameraState(defaultCameraState);
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
                    _targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + GameInitializer.current.fighterDataSO.CameraYOffset, GameInitializer.current.fighterDataSO.Camera_z);
                }

                _targetPosition += shakeOffset;

                _cameraScript.UpdateCameraPositionOnTarget(_targetPosition);
            }
        }
    }
}