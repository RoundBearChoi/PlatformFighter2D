using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class FightStage : BaseStage
    {
        [SerializeField]
        InputType _inputSelection = InputType.PLAYER_ONE;

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
                UserInput input = _inputController.AddInput(
                    BaseInitializer.current.arrInputDeviceData[0].keyboard,
                    BaseInitializer.current.arrInputDeviceData[0].mouse,
                    BaseInitializer.current.arrInputDeviceData[0].gamepad);

                player1.SetUserInput(input);
                _inputSelection = input.INPUT_TYPE;
            }

            //player 1
            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_DARK);
            Unit player2 = units.GetUnit<LittleRed>();

            if (BaseInitializer.current.arrInputDeviceData[1] != null)
            {
                UserInput input = _inputController.AddInput(
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

            //set camera
            FightCamera fightCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.FIGHT_CAMERA)) as FightCamera;
            fightCamera.transform.parent = this.transform;
            Camera cam = fightCamera.GetComponent<Camera>();
            cam.orthographicSize = 10f;
            cam.transform.position = new Vector3(8f, 4.5f, BaseInitializer.current.fighterDataSO.Camera_z);

            cameraScript = new CameraScript();
            cameraScript.SetCamera(cam);
            cameraScript.SetCameraState(GetStageDefaultCameraState());
            cameraScript.SetFollowTarget(player1.gameObject);

            //ui
            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;
            _baseUI.Init(BaseUIType.FIGHT_STAGE_UI);

            //gamepads
            //Debugger.Log("gamepads detected: " + UnityEngine.InputSystem.Gamepad.all.Count);
            //
            //for (int i = 0; i < UnityEngine.InputSystem.Gamepad.all.Count; i++)
            //{
            //    UserInput userInput = _inputController.GetUserInput(i);
            //
            //    if (userInput != null)
            //    {
            //        Debugger.Log("initiating: " + UnityEngine.InputSystem.Gamepad.all[i].name);
            //
            //        userInput.gamepad = UnityEngine.InputSystem.Gamepad.all[i];
            //        userInput.InitGamepadInput();
            //    }
            //}
        }

        public override void OnUpdate()
        {
            _inputController.GetUserInput(_inputSelection).OnUpdate();
            _baseUI.OnUpdate();

            cameraScript.OnUpdate();
            trailEffects.OnUpdate();
            units.OnUpdate();
            

            //temp

            if (_inputController.GetUserInput(_inputSelection).commands.ContainsPress(CommandType.F5, false))
            {
                _gameIntializer.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.FIGHT_STAGE));
            }

            if (_inputController.GetUserInput(_inputSelection).commands.ContainsPress(CommandType.F6, false))
            {
                _gameIntializer.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.INTRO_STAGE));
            }

            if (_inputController.GetUserInput(_inputSelection).commands.ContainsPress(CommandType.F7, false))
            {
                _inputSelection++;

                if ((int)_inputSelection > _inputController.GetCount())
                {
                    _inputSelection = InputType.PLAYER_ONE;
                }
            }
        }

        public override void OnFixedUpdate()
        {
            cameraScript.OnFixedUpdate();
            units.OnFixedUpdate();

            _baseUI.OnFixedUpdate();
            _inputController.ClearAllKeysAndButtons();
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

        public override CameraState GetStageDefaultCameraState()
        {
            return new Camera_LerpOnFighterXAndY(0.08f, 0.08f);
        }
    }
}