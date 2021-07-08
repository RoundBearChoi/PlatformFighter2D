using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController_Creator : UnitCreator
    {
        private Transform _parentTransform;
        private Unit _runner;

        public CameraController_Creator(Transform parentTransform, Unit runner, Camera gameCam)
        {
            _parentTransform = parentTransform;
            _runner = runner;
            CameraController.gameCam = gameCam;
        }

        public override Unit DefineUnit()
        {
            GameObject cameraConObj = new GameObject("cameraController(Clone)");
            cameraConObj.transform.parent = _parentTransform;
            cameraConObj.transform.localPosition = Vector3.zero;
            cameraConObj.transform.localRotation = Quaternion.identity;

            Unit cameraController = cameraConObj.AddComponent<CameraController>();

            cameraController.unitData = new UnitData(cameraController.transform);

            cameraController.iStateController = new StateController(
                new CameraController_SimpleFollow(_runner),
                cameraController.unitData);

            cameraController.unitData.spriteAnimations = new SpriteAnimations(cameraController.iStateController);

            return cameraController;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(DefineUnit());
        }
    }
}