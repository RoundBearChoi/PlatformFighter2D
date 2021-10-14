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
            UserInput input = inputController.AddFighterInput(UnityEngine.InputSystem.Keyboard.current, UnityEngine.InputSystem.Mouse.current, null);
            units = new Units(this);

            Physics2D.gravity = new Vector2(0f, -50);

            InstantiateUnits_ByUnitType(UnitType.RUNNER);
            Unit runner = units.GetUnit<Runner>();
            runner.SetFighterInput(input);

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
            cameraScript.SetCameraState(new Camera_LerpOnTargetY(), true);
            cameraScript.SetFollowTarget(runner.gameObject);
        }

        public override void OnUpdate()
        {
            InputController.centralUserInput.commands.UpdateKeyPresses();

            updateCounter.OnUpdate();
            units.OnUpdate();
            trailEffects.OnUpdate();
            ui.OnUpdate();
            cameraScript.OnUpdate();

            if (InputController.centralUserInput.commands.ContainsPress(CommandType.F5, false))
            {
                _gameIntializer.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.TEST_STAGE));
            }

            if (InputController.centralUserInput.commands.ContainsPress(CommandType.F6, false))
            {
                _gameIntializer.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.INTRO_STAGE));
            }
        }

        public override void OnFixedUpdate()
        {
            fixedUpdateCounter.OnFixedUpdate();
            units.OnFixedUpdate();
            ui.OnFixedUpdate();

            cameraScript.OnFixedUpdate();
        }

        public override void OnLateUpdate()
        {
            units.OnLateUpdate();
            cameraScript.OnLateUpdate();
        }

        public override float GetCumulativeGravityForcePercentage()
        {
            return BaseInitializer.current.runnerDataSO.CumulativeGravityForcePercentage;
        }
    }
}