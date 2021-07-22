using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Camera_Shake_OnTarget : CameraState
    {
        uint _totalShakeFrames = 0;
        float _shakeAmount = 0.5f;

        public Camera_Shake_OnTarget(uint totalShakeFrames)
        {
            _totalShakeFrames = totalShakeFrames;
        }

        public override void OnFixedUpdate()
        {
            if (_totalShakeFrames > 0)
            {
                Vector3 shakeOffset = new Vector3(Random.Range(-_shakeAmount, _shakeAmount), Random.Range(-_shakeAmount, _shakeAmount), 0f);

                GameObject target = CameraScript.current.GetTarget();

                if (target != null)
                {
                    _targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + 5f, target.transform.position.z - 5f);
                }

                _targetPosition += shakeOffset;

                CameraScript.current.UpdateCameraPositionOnTarget(_targetPosition);
            }
            else
            {
                CameraScript.current.SetCameraState(new Camera_FollowRunner());
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