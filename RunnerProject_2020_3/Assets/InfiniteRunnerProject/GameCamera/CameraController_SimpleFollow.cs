using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController_SimpleFollow : State
    {
        private Unit _targetRunner = null;
        private GameCameraController _runnerCam = null;
        private Vector3 _targetPosition;

        public CameraController_SimpleFollow(Unit runner, GameCameraController runnerCam)
        {
            _targetRunner = runner;
            _runnerCam = runnerCam;
            _targetPosition = Vector3.zero;
        }

        public override void OnFixedUpdate()
        {
            if (_targetRunner != null)
            {
                _targetPosition = new Vector3(_targetRunner.transform.position.x, _targetRunner.transform.position.y + 5f, _targetRunner.transform.position.z - 5f);
            }

            _runnerCam.mTargetPosition = _targetPosition;

            //Vector3 shakeOffset = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0f);
            //RunnerCam.gameCam.transform.position = _targetPosition + shakeOffset;
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return null;
        }
    }
}