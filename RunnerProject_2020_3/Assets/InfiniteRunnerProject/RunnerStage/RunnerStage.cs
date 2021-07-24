using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerStage : Stage
    {
        public override void Init()
        {
            _userInput = new UserInput();

            InstantiateUnit_ByUnitType(UnitType.RUNNER);
            InstantiateUnits_ByUnitType(UnitType.GOLEM);

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.GAME_UI)) as GameUI;
            _baseUI.transform.parent = this.transform;

            cameraScript = new CameraScript();
            Camera cam = FindObjectOfType<Camera>();
            cam.orthographicSize = 7f;
            cam.transform.position = new Vector3(0f, 5f, 0f);
            cameraScript.SetCamera(cam);
            cameraScript.SetCameraState(new Camera_LerpOnRunnerY());
            cameraScript.SetTarget(units.GetUnit<Runner>().gameObject);

            backgroundSetup = new SwampSetup();
            backgroundSetup.InstantiateBaseLayer();

            groundSetup = new FlatGroundSetup();
            groundSetup.InstantiateBaseLayer();

            Unit firstGround = units.GetUnit<Ground>();
            firstGround.transform.position -= new Vector3(20f, 0f, 0f);
        }

        public override void OnUpdate()
        {
            _userInput.OnUpdate();
            _baseUI.OnUpdate();
            units.OnUpdate();
            trailEffects.OnUpdate();
            cameraScript.OnUpdate();
        }

        public override void OnFixedUpdate()
        {
            units.OnFixedUpdate();

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f5Key))
            {
                _gameIntializer.stageTransitioner.AddTransition(new RunnerStageTransition(_gameIntializer));
            }

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f6Key))
            {
                _gameIntializer.stageTransitioner.AddTransition(new IntroStageTransition(_gameIntializer));
            }

            _userInput.ClearKeyDictionary();
            _userInput.ClearButtonDictionary();
            _baseUI.OnFixedUpdate();
            cameraScript.OnFixedUpdate();
        }

        public override void OnLateUpdate()
        {
            _baseUI.OnLateUpdate();
            units.OnLateUpdate();
            cameraScript.OnLateUpdate();
        }
    }
}