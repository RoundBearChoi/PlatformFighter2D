using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraScript
    {
        IStateController<CameraState> _cameraStateController = null;
        GameObject _target = null;
        Camera _camera = null;

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
            _cameraStateController.GetCurrentState().cameraUpdateCount++;
        }

        public void AddCameraState(CameraState cameraState)
        {
            _cameraStateController.SetNewState(cameraState);
        }

        public void SetCamera(Camera camera)
        {
            _camera = camera;
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        public GameObject GetTarget()
        {
            return _target;
        }
    }
}