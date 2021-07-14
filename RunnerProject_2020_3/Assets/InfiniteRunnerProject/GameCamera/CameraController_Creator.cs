using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController_Creator : BaseUnitCreator
    {
        private Unit _runner;

        public CameraController_Creator(Transform parentTransform, Unit runner, Camera gameCam)
        {
            _parentTransform = parentTransform;
            _runner = runner;
            RunnerCam.gameCam = gameCam;
        }

        public override Unit DefineUnit()
        {
            GameObject cameraConObj = new GameObject("cameraController(Clone)");
            cameraConObj.transform.parent = _parentTransform;
            cameraConObj.transform.localPosition = Vector3.zero;
            cameraConObj.transform.localRotation = Quaternion.identity;

            Unit cameraController = cameraConObj.AddComponent<RunnerCam>();
            RunnerCam.current = cameraController;

            cameraController.unitData = new UnitData(cameraController.transform);

            cameraController.iStateController = new StateController(cameraController);

            cameraController.iStateController.SetNewState(new CameraController_SimpleFollow(_runner, cameraController as RunnerCam));

            cameraController.unitData.spriteAnimations = new SpriteAnimations(cameraController.iStateController);

            return cameraController;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(DefineUnit());
        }
    }
}