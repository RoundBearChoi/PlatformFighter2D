using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraScript
    {
        public BaseMessageHandler messageHandler = null;
        public CameraEdges cameraEdges = null;

        IStateController<CameraState> _cameraStateController = null;
        GameObject _target = null;
        Camera _camera = null;

        public CameraScript()
        {
            _cameraStateController = new CameraStateController();
            messageHandler = new CameraMessageHandler(this);
        }

        public void OnUpdate()
        {
            _cameraStateController.OnUpdate();
        }

        public void OnFixedUpdate()
        {
            _cameraStateController.OnFixedUpdate();
            _cameraStateController.GetCurrentState().cameraUpdateCount++;

            cameraEdges.FixedUpdateEdges();
        }

        public void OnLateUpdate()
        {
            _cameraStateController.OnLateUpdate();
            messageHandler.HandleMessages();
            messageHandler.ClearMessages();
        }

        public void SetCameraState(CameraState cameraState)
        {
            _cameraStateController.SetNewState(cameraState);
        }

        public void SetCamera(Camera camera)
        {
            _camera = camera;
            cameraEdges = new CameraEdges(_camera);
        }

        public Camera GetCamera()
        {
            return _camera;
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        public GameObject GetTarget()
        {
            return _target;
        }

        public void UpdateCameraPositionOnTarget(Vector3 pos)
        {
            _camera.transform.position = pos;
        }
    }
}