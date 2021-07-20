using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class CameraState
    {
        public uint cameraUpdateCount = 0;

        protected Vector3 _targetPosition = Vector3.zero;

        public virtual void OnUpdate()
        {

        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void OnLateUpdate()
        {

        }
    }
}