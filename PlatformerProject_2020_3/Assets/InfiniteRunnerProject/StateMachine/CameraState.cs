using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class CameraState
    {
        public uint cameraUpdateCount = 0;
        public static CameraState defaultState = null;

        protected Vector3 _targetPosition = Vector3.zero;
        protected CameraScript _cameraScript = null;

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