using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController_SimpleFollow : State
    {
        private Unit _targetRunner = null;

        public CameraController_SimpleFollow(Unit runner)
        {
            _targetRunner = runner;
        }

        public override void OnFixedUpdate()
        {
            if (_targetRunner != null)
            {
                CameraController.gameCam.transform.position = new Vector3(_targetRunner.transform.position.x, _targetRunner.transform.position.y + 2.5f, _targetRunner.transform.position.z - 5f);
            }
        }

        public override SpriteAnimationSpec GetSpriteAnimationSpec()
        {
            return null;
        }
    }
}