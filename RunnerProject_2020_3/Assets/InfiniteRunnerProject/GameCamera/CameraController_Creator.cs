using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class CameraController_Creator : BaseUnitCreator
    {
        private Unit _runner;

        public CameraController_Creator(Transform parentTransform, Unit runner)
        {
            _parentTransform = parentTransform;
            _runner = runner;
        }

        public override Unit DefineUnit()
        {
            GameObject cameraConObj = new GameObject("cameraController(Clone)");
            cameraConObj.transform.parent = _parentTransform;
            cameraConObj.transform.localPosition = Vector3.zero;
            cameraConObj.transform.localRotation = Quaternion.identity;

            GameCameraController camController = cameraConObj.AddComponent<GameCameraController>();
            GameCameraController.current = camController;
            GameCameraController.current.gameCam = GameObject.FindObjectOfType<Camera>();

            camController.unitData = new UnitData(camController.transform);

            camController.iStateController = new StateController(camController);

            camController.iStateController.SetNewState(new CameraController_SimpleFollow(_runner, camController));

            camController.unitData.spriteAnimations = new SpriteAnimations(camController.iStateController);

            return camController;
        }

        public override void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(DefineUnit());
        }
    }
}