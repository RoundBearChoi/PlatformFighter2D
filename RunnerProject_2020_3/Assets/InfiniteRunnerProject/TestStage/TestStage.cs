using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class TestStage : Stage
    {
        private UITest.tempUI ui = null;
        private FixedUpdateCounter fixedUpdateCounter = new FixedUpdateCounter();
        private UpdateCounter updateCounter = new UpdateCounter();

        public override void Init()
        {
            _userInput = new UserInput();

            InstantiateUnits_ByUnitType(UnitType.RUNNER);

            units.ProcessCreators();

            //level and enemies
            GameObject levelObj = Instantiate(ResourceLoader.levelLoader.GetObj(1)) as GameObject;
            levelObj.transform.parent = this.transform;

            ui = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.UI)) as UITest.tempUI;
            ui.SetCounters(fixedUpdateCounter, updateCounter);
            ui.SetInput(_userInput);
            ui.transform.parent = this.transform;
            ui.transform.localPosition = Vector3.zero;
            ui.transform.localRotation = Quaternion.identity;

            UITest.tempUI.currentUI = ui;

            cameraScript = new CameraScript();
            cameraScript.SetCamera(FindObjectOfType<Camera>());
            cameraScript.SetCameraState(new Camera_FollowRunner());

            Unit runner = units.GetUnit<Runner>();
            cameraScript.SetTarget(runner.gameObject);
        }

        public override void OnUpdate()
        {
            updateCounter.OnUpdate();
            _userInput.OnUpdate();
            units.OnUpdate();
            ui.OnUpdate();
            cameraScript.OnUpdate();
        }

        public override void OnFixedUpdate()
        {
            fixedUpdateCounter.OnFixedUpdate();
            units.OnFixedUpdate();
            ui.OnFixedUpdate();

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f5Key))
            {
                _gameIntializer.stageTransitioner.AddTransition(new GameStageTransition(_gameIntializer));
            }

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f6Key))
            {
                _gameIntializer.stageTransitioner.AddTransition(new IntroStageTransition(_gameIntializer));
            }

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f10Key))
            {
                Unit runner = units.GetUnit<Runner>();
                runner.unitData.listNextStates.Add(new tempRunner_Death(runner));
            }

            _userInput.ClearKeyDictionary();
            _userInput.ClearButtonDictionary();

            cameraScript.OnFixedUpdate();
        }

        public override void OnLateUpdate()
        {
            units.OnLateUpdate();
            cameraScript.OnLateUpdate();
        }
    }
}