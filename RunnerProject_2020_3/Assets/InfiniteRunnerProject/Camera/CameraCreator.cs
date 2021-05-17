using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraCreator : UnitCreator
    {
        private Transform _parentTransform;
        private Unit _runner;
        private Camera _mainCamera;

        public CameraCreator(Transform parentTransform, Unit runner, Camera mainCamera)
        {
            _parentTransform = parentTransform;
            _runner = runner;
            _mainCamera = mainCamera;
        }

        public override Unit GetUnit()
        {
            GameObject cameraConObj = new GameObject("cameraController(Clone)");
            Unit cameraController = cameraConObj.AddComponent<CameraController>();
            cameraController.SetParent(_parentTransform);
            cameraController.stateController = new StateController(StateFactory.Create_CameraController_SimpleFollow(_runner, _mainCamera));

            return cameraController;
        }
    }
}