using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Game : MonoBehaviour
    {
        private Runner runner = null;
        private Obstacle obstacle = null;
        private UI ui = null;

        private FixedUpdateCounter fixedUpdateCounter = new FixedUpdateCounter();
        private UpdateCounter updateCounter = new UpdateCounter();
        private UserInput userInput = new UserInput();
        private CameraController cameraController = null;
        
        private bool restartGame = false;

        [SerializeField]
        private GameData gameDataScriptableObj = null;

        public bool RestartGame()
        {
            return restartGame;
        }

        public void Init()
        {
            StaticRefs.gameData = gameDataScriptableObj;
            
            runner = Instantiate(ResourceLoader.Get(typeof(Runner))) as Runner;
            runner.AttachSelf(this.transform);
            runner.elementData = new GameElementData(runner.transform);
            runner.stateController = new StateController(new Runner_Idle(runner.elementData, userInput));
            runner.SetUserInput(userInput);
            runner.SetCollisionDetector(ResourceLoader.Get(typeof(CollisionDetector)) as CollisionDetector);
            
            GameObject runnerSample = Instantiate(ResourceLoader.GetSprite(SpriteType.RUNNER_SAMPLE)) as GameObject;
            runner.AttachSprite(runnerSample.GetComponent<GameElementSprite>(), OffsetType.BOTTOM_CENTER);

            obstacle = Instantiate(ResourceLoader.Get(typeof(Obstacle))) as Obstacle;
            obstacle.AttachSelf(this.transform);
            obstacle.elementData = new GameElementData(obstacle.transform);
            obstacle.stateController = new StateController(new Obstacle_Idle(obstacle.elementData));

            GameObject obstacleWhiteBox = Instantiate(ResourceLoader.GetSprite(SpriteType.WHITE_BOX)) as GameObject;
            obstacle.AttachSprite(obstacleWhiteBox.GetComponent<GameElementSprite>(), OffsetType.BOTTOM_CENTER);

            cameraController = new CameraController(runner, FindObjectOfType<Camera>());

            ui = Instantiate(ResourceLoader.Get(typeof(UI))) as UI;
            ui.SetCounters(fixedUpdateCounter, updateCounter);
            ui.transform.parent = this.transform;
            ui.transform.localPosition = Vector3.zero;
            ui.transform.localRotation = Quaternion.identity;
        }

        public void OnUpdate()
        {
            updateCounter.OnUpdate();
            userInput.OnUpdate();
            ui.OnUpdate();
        }

        public void OnFixedUpdate()
        {
            fixedUpdateCounter.OnFixedUpdate();

            if (runner != null)
            {
                runner.OnFixedUpdate();
            }

            if (obstacle != null)
            {
                obstacle.OnFixedUpdate();
            }

            if (cameraController != null)
            {
                cameraController.OnFixedUpdate();
            }

            foreach(KeyPress press in userInput.listPresses)
            {
                if (press.keyCode == KeyCode.F5)
                {
                    restartGame = true;
                    break;
                }
            }

            userInput.listPresses.Clear();
        }
    }
}