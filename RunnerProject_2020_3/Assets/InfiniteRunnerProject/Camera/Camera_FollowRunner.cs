using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Camera_FollowRunner : CameraState
    {
        public Camera_FollowRunner()
        {

        }

        public override void OnUpdate()
        {

        }

        public override void OnFixedUpdate()
        {
            GameObject target = CameraScript.current.GetTarget();

            if (target != null)
            {
                _targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + 5f, target.transform.position.z - 5f);
            }

            CameraScript.current.UpdateCameraPositionOnTarget(_targetPosition);
        }
    }
}