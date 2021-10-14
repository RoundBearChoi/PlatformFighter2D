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

            Physics2D.gravity = new Vector2(0f, BaseInitializer.current.fighterDataSO.Gravity);

            //load level 3 (oldcity)
            GameObject levelObj = Instantiate(ResourceLoader.levelLoader.GetObj(3)) as GameObject;
            levelObj.transform.parent = this.transform;
            levelObj.transform.position = new Vector3(levelObj.transform.position.x, levelObj.transform.position.y, BaseInitializer.current.fighterDataSO.tempPlatforms_z);

            BaseInitializer.current.GetStage().InstantiateUnits_ByUnitType(UnitType.OLD_CITY);

            //player 0
            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_LIGHT);
            Unit player1 = units.GetUnit<LittleRed>();

            if (BaseInitializer.current.arrInputDeviceData[0] != null)
            {
                UserInput input = inputController.AddInput(
                    BaseInitializer.current.arrInputDeviceData[0].keyboard,
                    BaseInitializer.current.arrInputDeviceData[0].mouse,
                    BaseInitializer.current.arrInputDeviceData[0].gamepad);

                player1.SetUserInput(input);
            }

            //player 1
            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_DARK);
            Unit player2 = units.GetUnit<LittleRed>();

            if (BaseInitializer.current.arrInputDeviceData[1] != null)
            {
                UserInput input = inputController.AddInput(
                    BaseInitializer.current.arrInputDeviceData[1].keyboard,
                    BaseInitializer.current.arrInputDeviceData[1].mouse,
                    BaseInitializer.current.arrInputDeviceData[1].gamepad);

                player2.SetUserInput(input);
            }

            //set z for all players
            List<Unit> allPlayers = units.GetUnits<LittleRed>();

            foreach(Unit player in allPlayers)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, BaseInitializer.current.fighterDataSO.Players_z);
            }

            //midpoint
            GameObject midPoint = new GameObject();
            midPoint.name = "midPoint";
            midPoint.transform.parent = this.transform;
            _midPoint = new PlayersMidPoint(midPoint, player1, player2);

            //set camera
            FightCamera fightCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.FIGHT_CAMERA)) as FightCamera;
            fightCamera.transform.parent = this.transform;
            Camera cam = fightCamera.GetComponent<Camera>();
            cam.orthographicSize = 10f;
            cam.transform.position = new Vector3(8f, 4.5f, BaseInitializer.current.fighterDataSO.Camera_z);

            cameraScript = new CameraScript();
            cameraScript.SetCamera(cam);
            cameraScript.SetCameraState(new Camera_LerpOnFighterXAndY(0.08f, 0.08f, 10f, 52f, 4f), true);
            cameraScript.SetFollowTarget(midPoint);
            cameraScript.RegierViewPlayers(player1);
            cameraScript.RegierViewPlayers(player2);

            //ui
            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;
            _baseUI.Init(BaseUIType.FIGHT_STAGE_UI);
        }

        public override void OnUpdate()
        {
            inputController.UpdateInputDevices();
            _baseUI.OnUpdate();

            cameraScript.OnUpdate();
            trailEffects.OnUpdate();
            units.OnUpdate();

            //temp
            UserInput pcInput = inputController.GetPCUserInput();

            if (pcInput != null)
            {
                if (pcInput.commands.ContainsPress(CommandType.F5, false))
                {
                    _gameIntializer.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.FIGHT_STAGE));
                }

                if (pcInput.commands.ContainsPress(CommandType.F6, false))
                {
                    _gameIntializer.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.INTRO_STAGE));
                }
            }
        }

        public override void OnFixedUpdate()
        {
            cameraScript.OnFixedUpdate();
            units.OnFixedUpdate();

            _baseUI.OnFixedUpdate();
            _midPoint.OnFixedUpdate();
        }

        public override void OnLateUpdate()
        {
            _baseUI.OnLateUpdate();

            cameraScript.OnLateUpdate();
            units.OnLateUpdate();
        }

        public override float GetCumulativeGravityForcePercentage()
        {
            return BaseInitializer.current.fighterDataSO.CumulativeGravityForcePercentage;
        }
    }
}