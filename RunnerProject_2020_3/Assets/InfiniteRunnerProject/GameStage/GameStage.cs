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

        [SerializeField]
        private GameData gameDataScriptableObj = null;

        public override void Init()
        {
            StaticRefs.gameData = gameDataScriptableObj;

            GameObject levelObj = Instantiate(ResourceLoader.GetLevel(1)) as GameObject;

            units.AddCreator(new Runner_Creator(_userInput, this.transform));
            units.ProcessCreators();

            //units.AddCreator(new ObstaclePlacer_Creator(units.GetUnit(0), this));

            //temp
            //need way to find runner from units
            units.AddCreator(new CameraController_Creator(this.transform, units.GetUnit(0), FindObjectOfType<Camera>()));
            units.ProcessCreators();

            ui = Instantiate(ResourceLoader.GetResource(typeof(UI))) as UI;
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

            units.ProcessCreators();
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

            _userInput.ClearPressDictionary();
        }
    }
}