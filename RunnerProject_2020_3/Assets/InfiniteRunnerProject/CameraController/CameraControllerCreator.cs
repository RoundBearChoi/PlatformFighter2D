using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraControllerCreator : UnitCreator
    {
        private Transform _parentTransform;
        private Unit _runner;
        private Camera _mainCamera;

        public CameraControllerCreator(Transform parentTransform, Unit runner, Camera mainCamera)
        {
            _parentTransform = parentTransform;
            _runner = runner;
            _mainCamera = mainCamera;
        }

        public override Unit GetUnit()
        {
            GameObject cameraConObj = new GameObject("cameraController(Clone)");
            Unit cameraController = cameraConObj.AddComponent<CameraController>();
            cameraController.unitData = new UnitData(cameraController.transform);
            cameraController.transform.parent = _parentTransform;
            cameraController.transform.localPosition = Vector3.zero;
            cameraController.transform.localRotation = Quaternion.identity;
            cameraController.stateController = new StateController(new CameraController_SimpleFollow(_runner, _mainCamera));

            return cameraController;
        }
    }
}