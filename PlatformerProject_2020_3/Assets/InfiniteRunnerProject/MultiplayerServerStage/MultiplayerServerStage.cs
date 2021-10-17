using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Client;

namespace RB
{
    public class MultiplayerServerStage : BaseStage
    {
        [SerializeField]
        RB.Server.PlayerDataSender _playerDataSender = null;

        List<Unit> playerUnits = null;

        public override void Init()
        {
            units = new Units(this);
            playerUnits = new List<Unit>();

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

            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_LIGHT);
            Unit serverPlayer = units.GetUnit<LittleRed>();
            serverPlayer.SetFighterInput(InputController.centralUserInput);
            playerUnits.Add(serverPlayer);

            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_DARK);
            Unit client0 = units.GetUnit<LittleRed>();
            client0.SetFighterInput(inputController.AddFighterInput(UnityEngine.InputSystem.Keyboard.current, UnityEngine.InputSystem.Mouse.current, null));
            playerUnits.Add(client0);

            //set z for all players
            List<Unit> allPlayers = units.GetUnits<LittleRed>();

            foreach (Unit player in allPlayers)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.Players_z);
            }

            //data to send to clients
            _playerDataSender = new RB.Server.PlayerDataSender();
            _playerDataSender.AddUnit(serverPlayer, 100);

            RB.Server.ClientData[] allClients = RB.Server.ServerManager.CURRENT.serverController.clients.GetAllClients();

            for (int i = 0; i < allClients.Length; i++)
            {
                _playerDataSender.AddUnit(client0, allClients[i].serverTCP.ID);
                break;
            }

            _playerDataSender.SendPlayerUnitTypesToAllClients();

            //ui
            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;
            _baseUI.Init(BaseUIType.FIGHT_STAGE_UI);

            //set camera targets
            _cameraScript.SetCameraState(new Camera_LerpOnFighterXY(_cameraScript, 0.08f, 0.08f, 10f, 52f, 4f), true);
            _cameraScript.SetFollowTarget(serverPlayer.gameObject);
        }

        public override void OnUpdate()
        {
            InputController.centralUserInput.commands.UpdateKeyPresses();

            _playerDataSender.Send();
            _baseUI.OnUpdate();

            _cameraScript.OnUpdate();
            trailEffects.OnUpdate();
            units.OnUpdate();
            
            //temp

            if (InputController.centralUserInput.commands.ContainsPress(CommandType.F5, false))
            {
                _gameIntializer.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.FIGHT_STAGE));
            }

            if (InputController.centralUserInput.commands.ContainsPress(CommandType.F6, false))
            {
                _gameIntializer.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.INTRO_STAGE));
            }
        }

        public override void OnFixedUpdate()
        {
            _playerDataSender.Send();
            _baseUI.OnFixedUpdate();

            _cameraScript.OnFixedUpdate();
            units.OnFixedUpdate();
        }

        public override void OnLateUpdate()
        {
            _cameraScript.OnLateUpdate();
            units.OnLateUpdate();
            _baseUI.OnLateUpdate();
        }

        public override float GetCumulativeGravityForcePercentage()
        {
            return BaseInitializer.CURRENT.fighterDataSO.CumulativeGravityForcePercentage;
        }

        public override UserInput GetUserInputByClientIndex(int clientIndex)
        {
            foreach(Unit unit in playerUnits)
            {
                if (unit.clientIndex == clientIndex)
                {
                    return unit.USER_INPUT;
                }
            }

            return null;
        }
    }
}