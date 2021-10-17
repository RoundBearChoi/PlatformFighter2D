using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Camera_SlowMoveLeftRight : CameraState
    {
        private Vector3 _leftPos = new Vector3();
        private Vector3 _rightPos = new Vector3();
        private bool _moveLeft = false;
        
        public Camera_SlowMoveLeftRight(CameraScript cameraScript, Vector3 left, Vector3 right)
        {
            _leftPos = left;
            _rightPos = right;
            _cameraScript = cameraScript;
        }

        public override void OnUpdate()
        {

        }

        public override void OnFixedUpdate()
        {
            if (_cameraScript.CAMERA.transform.position.x <= _leftPos.x || Mathf.Abs(_cameraScript.CAMERA.transform.position.x - _leftPos.x) < 1.5f)
            {
                _moveLeft = false;
            }
            else if (_cameraScript.CAMERA.transform.position.x >= _rightPos.x || Mathf.Abs(_cameraScript.CAMERA.transform.position.x - _rightPos.x) < 1.5f)
            {
                _moveLeft = true;
            }

            if (_moveLeft)
            {
                Vector3 pos = new Vector3(_leftPos.x, _cameraScript.CAMERA.transform.position.y, _cameraScript.CAMERA.transform.position.z);
                _cameraScript.CAMERA.transform.position = Vector3.Lerp(_cameraScript.CAMERA.transform.position, pos, 0.001f);
            }
            else
            {
                Vector3 pos = new Vector3(_rightPos.x, _cameraScript.CAMERA.transform.position.y, _cameraScript.CAMERA.transform.position.z);
                _cameraScript.CAMERA.transform.position = Vector3.Lerp(_cameraScript.CAMERA.transform.position, pos, 0.001f);
            }
        }

        public override void OnLateUpdate()
        {

        }
    }
}