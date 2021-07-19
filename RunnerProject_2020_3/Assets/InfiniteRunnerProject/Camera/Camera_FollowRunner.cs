using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Camera_FollowRunner : CameraState
    {
        public Camera_FollowRunner(CameraScript cameraScript)
        {
            _cameraScript = cameraScript;
        }

        public override void OnUpdate()
        {

        }

        public override void OnFixedUpdate()
        {
            GameObject target = _cameraScript.GetTarget();

            if (target != null)
            {
                _targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + 5f, target.transform.position.z - 5f);
            }
        }
    }
}