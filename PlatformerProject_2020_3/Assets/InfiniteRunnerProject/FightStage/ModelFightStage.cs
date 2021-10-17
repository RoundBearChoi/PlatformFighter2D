using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class ModelFightStage : BaseStage
    {
        public override void Init()
        {
            units = new Units(this);

            //set camera
            ModelFightCamera modelFightCam = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.MODEL_FIGHT_CAMERA)) as ModelFightCamera;
            modelFightCam.transform.parent = this.transform;
            Camera cam = modelFightCam.GetComponent<Camera>();
            cam.orthographicSize = 10f;
            cam.transform.position = new Vector3(30f, 7f, BaseInitializer.CURRENT.fighterDataSO.Camera_z);
            _cameraScript = new CameraScript();
            _cameraScript.SetCamera(cam);

            //load level 3 (oldcity)
            GameObject levelObj = Instantiate(ResourceLoader.levelLoader.GetObj(3)) as GameObject;
            levelObj.transform.parent = this.transform;
            levelObj.transform.position = new Vector3(levelObj.transform.position.x, levelObj.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.tempPlatforms_z);

            InstantiateUnits_ByUnitType(UnitType.OLD_CITY);

            //fighter model
            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_LIGHT);
            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_DARK);

            units.GetUnit<LittleRed>().unitData.facingRight = false;

            //set z for all players
            List<Unit> allPlayers = units.GetUnits<LittleRed>();

            foreach (Unit player in allPlayers)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.Players_z);
            }

            //set camera targets
            //_cameraScript.SetCameraState(new Camera_LerpOnFighterXY(_cameraScript, 0.08f, 0.08f, 10f, 52f, 4f), true);
            //_cameraScript.SetFollowTarget(midPoint);
            //_cameraScript.RegisterViewPlayers(player1);
            //_cameraScript.RegisterViewPlayers(player2);
        }

        public override void OnUpdate()
        {
            _cameraScript.OnUpdate();
            units.OnUpdate();
        }

        public override void OnFixedUpdate()
        {
            _cameraScript.OnFixedUpdate();
            units.OnFixedUpdate();
        }

        public override void OnLateUpdate()
        {
            _cameraScript.OnLateUpdate();
            units.OnLateUpdate();
        }
    }
}