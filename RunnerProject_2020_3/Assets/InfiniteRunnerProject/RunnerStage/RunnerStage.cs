using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerStage : BaseStage
    {
        public override void Init()
        {
            UserInput input = _inputController.AddInput();
            units = new Units(this);

            Physics2D.gravity = new Vector2(0f, -50);

            InstantiateUnit_ByUnitType(UnitType.RUNNER);
            Unit runner = units.GetUnit<Runner>();
            runner.SetUserInput(input);

            cameraScript = new CameraScript();

            GameCamera gameCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.GAME_CAMERA)) as GameCamera;
            gameCamera.transform.parent = this.transform;
            Camera cam = gameCamera.GetComponent<Camera>();

            cam.orthographicSize = 8f;
            cam.transform.position = new Vector3(0f, 5f, 0f);
            cameraScript.SetCamera(cam);
            cameraScript.SetCameraState(new Camera_LerpOnTargetY());
            cameraScript.SetFollowTarget(units.GetUnit<Runner>().gameObject);

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
            _inputController.GetUserInput(InputType.PLAYER_ONE).OnUpdate();
            _baseUI.OnUpdate();
            units.OnUpdate();
            trailEffects.OnUpdate();
            cameraScript.OnUpdate();
            npcSetup.UPDATER.CustomUpdate();

            if (_inputController.GetUserInput(InputType.PLAYER_ONE).commands.ContainsPress(CommandType.F5))
            {
                _gameIntializer.stageTransitioner.AddTransition(new RunnerStageTransition(_gameIntializer));
            }

            if (_inputController.GetUserInput(InputType.PLAYER_ONE).commands.ContainsPress(CommandType.F6))
            {
                _gameIntializer.stageTransitioner.AddTransition(new IntroStageTransition(_gameIntializer));
            }
        }

        public override void OnFixedUpdate()
        {
            units.OnFixedUpdate();

            _inputController.GetUserInput(InputType.PLAYER_ONE).commands.ClearKeyPressDictionary();
            _inputController.GetUserInput(InputType.PLAYER_ONE).commands.ClearButtonPressDictionary();
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

        public override float GetCumulativeGravityForcePercentage()
        {
            return GameInitializer.current.runnerDataSO.CumulativeGravityForcePercentage;
        }

        public override CameraState GetDefaultCameraState()
        {
            return new Camera_LerpOnTargetY();
        }
    }
}