using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Camera_LerpOnTargetXAndY : CameraState
    {
        float _yOffsetOnPlayer = 4f;
        float _xPercentage = 0f;
        float _yPercentage = 0f;

        public Camera_LerpOnTargetXAndY(float xPercentage, float yPercentage)
        {
            _cameraScript = GameInitializer.current.GetStage().cameraScript;
            _xPercentage = xPercentage;
            _yPercentage = yPercentage;
        }

        public override void OnFixedUpdate()
        {
            GameObject target = _cameraScript.GetTarget();
            Camera currentCam = _cameraScript.GetCamera();

            if (target != null)
            {
                float x = Mathf.Lerp(_cameraScript.GetCamera().transform.position.x, target.transform.position.x, _xPercentage);
                float y = Mathf.Lerp(_cameraScript.GetCamera().transform.position.y, target.transform.position.y + _yOffsetOnPlayer, _yPercentage);

                if (GameInitializer.current.GetStage() is FightStage)
                {
                    _targetPosition = new Vector3(x, y, GameInitializer.current.fighterDataSO.Camera_z);
                }
            }

            _cameraScript.UpdateCameraPositionOnTarget(_targetPosition);
        }
    }
}