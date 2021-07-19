using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraScript
    {
        IStateController<CameraState> _cameraStateController = null;

        public CameraScript()
        {
            _cameraStateController = new CameraStateController();
        }

        public void OnUpdate()
        {
            _cameraStateController.OnUpdate();
        }

        public void OnFixedUpdate()
        {
            _cameraStateController.OnFixedUpdate();
        }

        public void AddCameraState(CameraState cameraState)
        {
            _cameraStateController.SetNewState(cameraState);
        }
    }
}