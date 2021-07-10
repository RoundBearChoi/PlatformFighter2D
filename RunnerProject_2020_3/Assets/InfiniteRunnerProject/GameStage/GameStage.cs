using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameStage : Stage
    {
        private UI ui = null;
        private FixedUpdateCounter fixedUpdateCounter = new FixedUpdateCounter();
        private UpdateCounter updateCounter = new UpdateCounter();
        private UserInput _userInput = new UserInput();

        public override void Init()
        {
            BaseUnitCreationSpec runnerSpec = StaticRefs.GetSpec(UnitType.RUNNER);
            units.AddCreator(new DefaultUnitCreator(_userInput, this.transform, runnerSpec));
            units.ProcessCreators();

            Unit runner = units.GetUnit<Runner>();
            
            units.AddCreator(new CameraController_Creator(this.transform, runner, FindObjectOfType<Camera>()));
            units.ProcessCreators();

            //level and enemies
            GameObject levelObj = Instantiate(ResourceLoader.levelLoader.GetObj(1)) as GameObject;
            levelObj.transform.parent = this.transform;

            //FrontEnemySpawn[] arr = levelObj.GetComponentsInChildren<FrontEnemySpawn>();
            //FrontEnemyCreator frontEnemyCreator = new FrontEnemyCreator(this.transform);
            //
            //foreach(FrontEnemySpawn spawn in arr)
            //{
            //    Debugger.Log("spawning enemy: " + spawn.gameObject.name + " " + spawn.transform.position);
            //    Unit frontEnemyUnit = frontEnemyCreator.DefineUnit();
            //    frontEnemyUnit.transform.position = spawn.transform.position;
            //    frontEnemyUnit.transform.parent = levelObj.transform;
            //
            //    if (frontEnemyUnit != null)
            //    {
            //        units.AddUnit(frontEnemyUnit);
            //    }
            //}

            ui = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.UI)) as UI;
            ui.SetCounters(fixedUpdateCounter, updateCounter);
            ui.SetInput(_userInput);
            ui.transform.parent = this.transform;
            ui.transform.localPosition = Vector3.zero;
            ui.transform.localRotation = Quaternion.identity;

            UIMessage.ui = ui;
        }

        public override void OnUpdate()
        {
            updateCounter.OnUpdate();
            _userInput.OnUpdate();
            ui.OnUpdate();
        }

        public override void OnFixedUpdate()
        {
            fixedUpdateCounter.OnFixedUpdate();
            units.OnFixedUpdate();
            ui.OnFixedUpdate();

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f5Key))
            {
                _gameIntializer.listStageTransitions.Add(new GameStageTransition(_gameIntializer));
            }

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f6Key))
            {
                _gameIntializer.listStageTransitions.Add(new IntroStageTransition(_gameIntializer));
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