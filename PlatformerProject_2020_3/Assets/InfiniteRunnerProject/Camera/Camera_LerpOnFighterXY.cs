using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Camera_LerpOnFighterXY : CameraState
    {
        float _xPercentage = 0f;
        float _yPercentage = 0f;

        float _leftXLimit = 0f;
        float _rightXLimit = 0f;
        float _lowYLimit = 0f;

        public Camera_LerpOnFighterXY(CameraScript cameraScript, float xPercentage, float yPercentage, float leftXLimit, float rightXLimit, float lowYLimit)
        {
            _cameraScript = cameraScript;
            _xPercentage = xPercentage;
            _yPercentage = yPercentage;

            _leftXLimit = leftXLimit;
            _rightXLimit = rightXLimit;
            _lowYLimit = lowYLimit;
        }

        public override void OnFixedUpdate()
        {
            if (_cameraScript.TARGET_OBJ != null)
            {
                float x = Mathf.Lerp(
                    _cameraScript.TARGET_OBJ.transform.position.x,
                    _cameraScript.TARGET_OBJ.transform.position.x,
                    _xPercentage);

                float y = Mathf.Lerp(
                    _cameraScript.TARGET_OBJ.transform.position.y,
                    _cameraScript.TARGET_OBJ.transform.position.y + BaseInitializer.CURRENT.fighterDataSO.CameraYOffset,
                    _yPercentage);

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

                _targetPosition = new Vector3(x, y, BaseInitializer.CURRENT.fighterDataSO.Camera_z);
            }

            _cameraScript.UpdateCameraPositionOnTarget(_targetPosition);
        }
    }
}