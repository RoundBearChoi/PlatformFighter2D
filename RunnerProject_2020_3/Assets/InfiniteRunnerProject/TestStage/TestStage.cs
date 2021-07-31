using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TestStage : BaseStage
    {
        private UITest.tempUI ui = null;
        private FixedUpdateCounter fixedUpdateCounter = new FixedUpdateCounter();
        private UpdateCounter updateCounter = new UpdateCounter();

        public override void Init()
        {
            UserInput input = _inputController.AddInput();
            units = new Units(this);

            Physics2D.gravity = new Vector2(0f, -50);

            InstantiateUnits_ByUnitType(UnitType.RUNNER);
            Unit runner = units.GetUnit<Runner>();
            runner.SetUserInput(input);

            //level and enemies
            GameObject levelObj = Instantiate(ResourceLoader.levelLoader.GetObj(1)) as GameObject;
            levelObj.transform.parent = this.transform;

            ui = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.UI)) as UITest.tempUI;
            ui.SetCounters(fixedUpdateCounter, updateCounter);
            ui.SetInput(input);
            ui.transform.parent = this.transform;
            ui.transform.localPosition = Vector3.zero;
            ui.transform.localRotation = Quaternion.identity;

            UITest.tempUI.currentUI = ui;

            cameraScript = new CameraScript();

            GameCamera gameCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.GAME_CAMERA)) as GameCamera;
            Camera camera = gameCamera.GetComponent<Camera>();
            gameCamera.transform.parent = this.transform;

            cameraScript.SetCamera(camera);
            cameraScript.SetCameraState(new Camera_LerpOnTargetY());
            cameraScript.SetFollowTarget(runner.gameObject);
        }

        public override void OnUpdate()
        {
            updateCounter.OnUpdate();
            _inputController.GetUserInput(InputType.PLAYER_ONE).OnUpdate();
            units.OnUpdate();
            trailEffects.OnUpdate();
            ui.OnUpdate();
            cameraScript.OnUpdate();

            if (_inputController.GetUserInput(InputType.PLAYER_ONE).commands.ContainsPress(CommandType.F5))
            {
                _gameIntializer.stageTransitioner.AddTransition(new TestStageTransition(_gameIntializer));
            }

            if (_inputController.GetUserInput(InputType.PLAYER_ONE).commands.ContainsPress(CommandType.F6))
            {
                _gameIntializer.stageTransitioner.AddTransition(new IntroStageTransition(_gameIntializer));
            }
        }

        public override void OnFixedUpdate()
        {
            fixedUpdateCounter.OnFixedUpdate();
            units.OnFixedUpdate();
            ui.OnFixedUpdate();

            _inputController.GetUserInput(InputType.PLAYER_ONE).commands.ClearKeyDictionary();
            _inputController.GetUserInput(InputType.PLAYER_ONE).commands.ClearButtonDictionary();

            cameraScript.OnFixedUpdate();
        }

        public override void OnLateUpdate()
        {
            units.OnLateUpdate();
            cameraScript.OnLateUpdate();
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