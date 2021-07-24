using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Camera_LerpOnRunnerY : CameraState
    {
        float _yOffsetOnPlayer = 5f;

        public Camera_LerpOnRunnerY()
        {

        }

        public override void OnFixedUpdate()
        {
            GameObject target = CameraScript.current.GetTarget();
            Camera currentCam = CameraScript.current.GetCamera();

            if (target != null)
            {
                float lerpPercentage = 0.005f;

                if (currentCam.transform.position.y > target.transform.position.y + _yOffsetOnPlayer)
                {
                    lerpPercentage = 0.05f;
                }

                float camY = Mathf.Lerp(CameraScript.current.GetCamera().transform.position.y, target.transform.position.y + _yOffsetOnPlayer, lerpPercentage);

                _targetPosition = new Vector3(target.transform.position.x, camY, target.transform.position.z - 5f);
            }

            CameraScript.current.UpdateCameraPositionOnTarget(_targetPosition);
        }
    }
}