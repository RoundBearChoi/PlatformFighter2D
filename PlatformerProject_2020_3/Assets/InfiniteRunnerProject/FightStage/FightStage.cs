using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FightStage : BaseStage
    {
        PlayersMidPoint _midPoint = null;

        public override void Init()
        {
            units = new Units(this);

            Physics2D.gravity = new Vector2(0f, BaseInitializer.CURRENT.fighterDataSO.Gravity);

            //set camera
            FightCamera fightCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.FIGHT_CAMERA)) as FightCamera;
            fightCamera.transform.parent = this.transform;
            Camera cam = fightCamera.GetComponent<Camera>();
            cam.orthographicSize = 10f;
            cam.transform.position = new Vector3(8f, 4.5f, BaseInitializer.CURRENT.fighterDataSO.Camera_z);
            _cameraScript = new CameraScript();
            _cameraScript.SetCamera(cam);

            //load level 3 (oldcity)
            GameObject levelObj = Instantiate(ResourceLoader.levelLoader.GetObj(3)) as GameObject;
            levelObj.transform.parent = this.transform;
            levelObj.transform.position = new Vector3(levelObj.transform.position.x, levelObj.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.tempPlatforms_z);

            InstantiateUnits_ByUnitType(UnitType.OLD_CITY);

            //player 0
            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_LIGHT);
            Unit player1 = units.GetUnit<LittleRed>();

            if (BaseInitializer.CURRENT.arrInputDeviceData[0] != null)
            {
                UserInput input = inputController.AddFighterInput(
                    BaseInitializer.CURRENT.arrInputDeviceData[0].keyboard,
                    BaseInitializer.CURRENT.arrInputDeviceData[0].mouse,
                    BaseInitializer.CURRENT.arrInputDeviceData[0].gamepad);

                player1.SetFighterInput(input);
            }

            //player 1
            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_DARK);
            Unit player2 = units.GetUnit<LittleRed>();

            if (BaseInitializer.CURRENT.arrInputDeviceData[1] != null)
            {
                UserInput input = inputController.AddFighterInput(
                    BaseInitializer.CURRENT.arrInputDeviceData[1].keyboard,
                    BaseInitializer.CURRENT.arrInputDeviceData[1].mouse,
                    BaseInitializer.CURRENT.arrInputDeviceData[1].gamepad);

                player2.SetFighterInput(input);
            }

            //set z for all players
            List<Unit> allPlayers = units.GetUnits<LittleRed>();

            foreach(Unit player in allPlayers)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.Players_z);
            }

            //midpoint
            GameObject midPoint = new GameObject();
            midPoint.name = "midPoint";
            midPoint.transform.parent = this.transform;
            _midPoint = new PlayersMidPoint(midPoint, player1, player2);

            //ui
            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;
            _baseUI.Init(BaseUIType.FIGHT_STAGE_UI);

            //set camera targets
            _cameraScript.SetCameraState(new Camera_LerpOnFighterXY(_cameraScript, 0.08f, 0.08f, 10f, 52f, 4f), true);
            _cameraScript.SetFollowTarget(midPoint);
            _cameraScript.RegisterViewPlayers(player1);
            _cameraScript.RegisterViewPlayers(player2);
        }

        public override void OnUpdate()
        {
            InputController.centralUserInput.commands.UpdateKeyPresses();
            inputController.UpdateInputDevices();

            _baseUI.OnUpdate();

            _cameraScript.OnUpdate();
            trailEffects.OnUpdate();
            units.OnUpdate();
        }

        public override void OnFixedUpdate()
        {
            _cameraScript.OnFixedUpdate();
            units.OnFixedUpdate();

            _baseUI.OnFixedUpdate();
            _midPoint.OnFixedUpdate();
        }

        public override void OnLateUpdate()
        {
            _baseUI.OnLateUpdate();

            _cameraScript.OnLateUpdate();
            units.OnLateUpdate();
        }

        public override float GetCumulativeGravityForcePercentage()
        {
            return BaseInitializer.CURRENT.fighterDataSO.CumulativeGravityForcePercentage;
        }
    }
}