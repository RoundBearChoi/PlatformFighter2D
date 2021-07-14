using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController_SimpleFollow : State
    {
        private Unit _targetRunner = null;
        private GameCameraController _cameraController = null;
        private Vector3 _targetPosition;

        public CameraController_SimpleFollow(Unit runner, GameCameraController cameraController)
        {
            _targetRunner = runner;
            _cameraController = cameraController;
            _targetPosition = Vector3.zero;
        }

        public override void OnFixedUpdate()
        {
            if (_targetRunner != null)
            {
                _targetPosition = new Vector3(_targetRunner.transform.position.x, _targetRunner.transform.position.y + 5f, _targetRunner.transform.position.z - 5f);
            }

            _cameraController.mTargetPosition = _targetPosition;
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return null;
        }
    }
}