using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Client;

namespace RB
{
    public class MultiplayerServerStage : BaseStage
    {
        [SerializeField]
        InputType _inputSelection = InputType.PLAYER_ONE;

        [SerializeField]
        RB.Server.PlayerDataSender _playerDataSender = null;

        public override void Init()
        {
            units = new Units(this);

            Physics2D.gravity = new Vector2(0f, BaseInitializer.current.fighterDataSO.Gravity);

            FightCamera fightCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.FIGHT_CAMERA)) as FightCamera;
            fightCamera.transform.parent = this.transform;
            Camera cam = fightCamera.GetComponent<Camera>();
            cam.orthographicSize = 10f;
            cam.transform.position = new Vector3(8f, 4.5f, BaseInitializer.current.fighterDataSO.Camera_z);

            //load level 3 (oldcity)
            GameObject levelObj = Instantiate(ResourceLoader.levelLoader.GetObj(3)) as GameObject;
            levelObj.transform.parent = this.transform;
            levelObj.transform.position = new Vector3(levelObj.transform.position.x, levelObj.transform.position.y, BaseInitializer.current.fighterDataSO.tempPlatforms_z);

            BaseInitializer.current.GetStage().InstantiateUnits_ByUnitType(UnitType.OLD_CITY);

            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_LIGHT);
            Unit serverPlayer = units.GetUnit<LittleRed>();

            UserInput input = _inputController.AddInput();
            _inputSelection = input.INPUT_TYPE;
            serverPlayer.SetUserInput(input);

            cameraScript = new CameraScript();
            cameraScript.SetCamera(cam);
            cameraScript.SetCameraState(GetDefaultCameraState());
            cameraScript.SetFollowTarget(units.GetUnit<LittleRed>().gameObject);

            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_DARK);
            Unit client0 = units.GetUnit<LittleRed>();
            client0.SetUserInput(_inputController.AddInput());

            //set z for all players
            List<Unit> allPlayers = units.GetUnits<LittleRed>();

            foreach (Unit player in allPlayers)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, BaseInitializer.current.fighterDataSO.Players_z);
            }

            //data to send to clients
            _playerDataSender = new RB.Server.PlayerDataSender();
            _playerDataSender.AddUnit(serverPlayer, 100);
            _playerDataSender.AddUnit(client0, 0);

            _playerDataSender.SendPlayerUnitTypesToAllClients();
        }

        public override void OnUpdate()
        {
            _inputController.GetUserInput(_inputSelection).OnUpdate();
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
            _playerDataSender.OnFixedUpdate();

            ClearInput();
        }

        public override void OnLateUpdate()
        {
            cameraScript.OnLateUpdate();
            units.OnLateUpdate();
        }

        public override float GetCumulativeGravityForcePercentage()
        {
            return BaseInitializer.current.fighterDataSO.CumulativeGravityForcePercentage;
        }

        public override CameraState GetDefaultCameraState()
        {
            return new Camera_LerpOnTargetXAndY(0.08f, 0.08f);
        }
    }
}