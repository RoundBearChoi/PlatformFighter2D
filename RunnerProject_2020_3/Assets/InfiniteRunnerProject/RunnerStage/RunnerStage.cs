using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerStage : BaseStage
    {
        public override void Init()
        {
            _userInput = new UserInput();
            units = new Units(this);

            InstantiateUnit_ByUnitType(UnitType.RUNNER);

            cameraScript = new CameraScript();

            GameCamera gameCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.GAME_CAMERA)) as GameCamera;
            gameCamera.transform.parent = this.transform;
            Camera cam = gameCamera.GetComponent<Camera>();

            cam.orthographicSize = 8f;
            cam.transform.position = new Vector3(0f, 5f, 0f);
            cameraScript.SetCamera(cam);
            cameraScript.SetCameraState(new Camera_LerpOnRunnerY());
            cameraScript.SetTarget(units.GetUnit<PlayerUnit>().gameObject);

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.GAME_UI)) as GameUI;
            _baseUI.transform.parent = this.transform;

            backgroundSetup = new SwampSetup();
            backgroundSetup.InstantiateBaseLayer();

            groundSetup = new FlatGroundSetup();
            groundSetup.InstantiateBaseLayer();

            Unit firstGround = units.GetUnit<Ground>();
            firstGround.transform.position -= new Vector3(20f, 0f, 0f);

            npcSetup = new RunnerStageNPCSetup(this);
        }

        public override void OnUpdate()
        {
            _userInput.OnUpdate();
            _baseUI.OnUpdate();
            units.OnUpdate();
            trailEffects.OnUpdate();
            cameraScript.OnUpdate();
            npcSetup.UPDATER.CustomUpdate();
        }

        public override void OnFixedUpdate()
        {
            units.OnFixedUpdate();

            if (_userInput.userCommands.ContainsPress(CommandType.F5))
            {
                _gameIntializer.stageTransitioner.AddTransition(new RunnerStageTransition(_gameIntializer));
            }

            if (_userInput.userCommands.ContainsPress(CommandType.F6))
            {
                _gameIntializer.stageTransitioner.AddTransition(new IntroStageTransition(_gameIntializer));
            }

            _userInput.userCommands.ClearKeyDictionary();
            _userInput.userCommands.ClearButtonDictionary();
            _baseUI.OnFixedUpdate();
            cameraScript.OnFixedUpdate();
            npcSetup.UPDATER.CustomFixedUpdate();
        }

        public override void OnLateUpdate()
        {
            _baseUI.OnLateUpdate();
            units.OnLateUpdate();
            cameraScript.OnLateUpdate();
            npcSetup.UPDATER.CustomLateUpdate();
        }
    }
}