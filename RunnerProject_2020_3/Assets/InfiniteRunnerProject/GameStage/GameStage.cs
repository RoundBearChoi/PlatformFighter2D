using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameStage : Stage
    {
        private UITest.UI ui = null;
        private FixedUpdateCounter fixedUpdateCounter = new FixedUpdateCounter();
        private UpdateCounter updateCounter = new UpdateCounter();

        public override void Init()
        {
            InstantiateUnits_ByUnitType(UnitType.RUNNER, _userInput);

            Unit runner = units.GetUnit<Runner>();
            
            units.AddCreator(new CameraController_Creator(this.transform, runner));
            units.ProcessCreators();

            //level and enemies
            GameObject levelObj = Instantiate(ResourceLoader.levelLoader.GetObj(1)) as GameObject;
            levelObj.transform.parent = this.transform;

            ui = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.UI)) as UITest.UI;
            ui.SetCounters(fixedUpdateCounter, updateCounter);
            ui.SetInput(_userInput);
            ui.transform.parent = this.transform;
            ui.transform.localPosition = Vector3.zero;
            ui.transform.localRotation = Quaternion.identity;

            UITest.UI.currentUI = ui;
        }

        public override void OnUpdate()
        {
            updateCounter.OnUpdate();
            _userInput.OnUpdate();
            units.OnUpdate();
            ui.OnUpdate();
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
                runner.unitData.listNextStates.Add(new Runner_Death(runner));
            }

            _userInput.ClearKeyDictionary();
            _userInput.ClearButtonDictionary();
        }

        public override void OnLateUpdate()
        {
            units.OnLateUpdate();
        }
    }
}