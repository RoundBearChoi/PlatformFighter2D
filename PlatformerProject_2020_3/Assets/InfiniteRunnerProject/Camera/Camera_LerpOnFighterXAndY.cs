using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Camera_LerpOnFighterXAndY : CameraState
    {
        float _xPercentage = 0f;
        float _yPercentage = 0f;

        float _leftXLimit = 0f;
        float _rightXLimit = 0f;
        float _lowYLimit = 0f;

        public Camera_LerpOnFighterXAndY(float xPercentage, float yPercentage, float leftXLimit, float rightXLimit, float lowYLimit)
        {
            _cameraScript = BaseInitializer.current.GetStage().cameraScript;
            _xPercentage = xPercentage;
            _yPercentage = yPercentage;

            _leftXLimit = leftXLimit;
            _rightXLimit = rightXLimit;
            _lowYLimit = lowYLimit;
        }

        public override void OnFixedUpdate()
        {
            GameObject target = _cameraScript.GetTarget();

            if (target != null)
            {
                float x = Mathf.Lerp(_cameraScript.GetCamera().transform.position.x, target.transform.position.x, _xPercentage);
                float y = Mathf.Lerp(_cameraScript.GetCamera().transform.position.y, target.transform.position.y + BaseInitializer.current.fighterDataSO.CameraYOffset, _yPercentage);

                if (x < _leftXLimit)
                {
                    x = _leftXLimit;
                }

                if (x > _rightXLimit)
                {
                    x = _rightXLimit;
                }

                if (y < _lowYLimit)
                {
                    y = _lowYLimit;
                }

                _targetPosition = new Vector3(x, y, BaseInitializer.current.fighterDataSO.Camera_z);
            }

            _cameraScript.UpdateCameraPositionOnTarget(_targetPosition);
        }
    }
}