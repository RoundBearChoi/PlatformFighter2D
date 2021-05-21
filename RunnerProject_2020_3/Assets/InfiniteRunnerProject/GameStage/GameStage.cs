using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameStage : Stage
    {
        public Units units = new Units();

        private UI ui = null;
        private FixedUpdateCounter fixedUpdateCounter = new FixedUpdateCounter();
        private UpdateCounter updateCounter = new UpdateCounter();
        private UserInput userInput = new UserInput();

        [SerializeField]
        private GameData gameDataScriptableObj = null;

        public override void Init()
        {
            StaticRefs.gameData = gameDataScriptableObj;

            RunnerCreator runnerCreator = new RunnerCreator(userInput, this.transform);
            Unit runner = runnerCreator.GetUnit();

            CameraControllerCreator cameraCreator = new CameraControllerCreator(this.transform, runner, FindObjectOfType<Camera>());
            Unit cameraController = cameraCreator.GetUnit();

            ObstaclePlacerCreator opCreator = new ObstaclePlacerCreator(runner, this);
            Unit placer = opCreator.GetUnit();

            units.AddUnit(runner);
            units.AddUnit(cameraController);
            units.AddUnit(placer);

            ui = Instantiate(ResourceLoader.Get(typeof(UI))) as UI;
            ui.SetCounters(fixedUpdateCounter, updateCounter);
            ui.transform.parent = this.transform;
            ui.transform.localPosition = Vector3.zero;
            ui.transform.localRotation = Quaternion.identity;
        }

        public override void OnUpdate()
        {
            updateCounter.OnUpdate();
            userInput.OnUpdate();
            ui.OnUpdate();
        }

        public override void OnFixedUpdate()
        {
            fixedUpdateCounter.OnFixedUpdate();
            units.OnFixedUpdate();

            foreach (KeyPress press in userInput.listPresses)
            {
                if (press.keyCode == KeyCode.F5)
                {
                    _gameIntializer.stageTransition = new GameStageTransition(_gameIntializer);
                    break;
                }

                if (press.keyCode == KeyCode.F6)
                {
                    _gameIntializer.stageTransition = new IntroStageTransition(_gameIntializer);
                    break;
                }
            }

            userInput.listPresses.Clear();
        }
    }
}