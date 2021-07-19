using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class CameraState
    {
        public uint cameraUpdateCount = 0;

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