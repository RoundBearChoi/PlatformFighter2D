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
            runner.AttachTo(this.transform);
            runner.unitData = new UnitData(runner.transform);
            runner.stateController = new StateController(new Runner_Idle(runner.unitData, userInput));

            CollisionDetector runnerCollider = Instantiate(ResourceLoader.Get(typeof(CollisionDetector)) as CollisionDetector);
            runnerCollider.InitBoxCollider(new Vector2(2f, 3f));
            runnerCollider.transform.parent = runner.transform;
            runnerCollider.transform.localRotation = Quaternion.identity;
            runnerCollider.transform.localPosition = new Vector3(0f, 1.5f, 0f);

            GameObject runnerSample = Instantiate(ResourceLoader.GetSprite(SpriteType.RUNNER_SAMPLE)) as GameObject;
            runner.AttachSprite(runnerSample.GetComponent<UnitSprite>(), new Vector2(2f, 3f), OffsetType.BOTTOM_CENTER);

            obstacle = Instantiate(ResourceLoader.Get(typeof(Obstacle))) as Obstacle;
            obstacle.AttachTo(this.transform);
            obstacle.unitData = new UnitData(obstacle.transform);
            obstacle.stateController = new StateController(new Obstacle_Idle(obstacle.unitData));

            CollisionDetector obsCollider = Instantiate(ResourceLoader.Get(typeof(CollisionDetector)) as CollisionDetector);
            obsCollider.InitBoxCollider(new Vector2(3f, 5f));
            obsCollider.transform.parent = obstacle.transform;
            obsCollider.transform.localRotation = Quaternion.identity;
            obsCollider.transform.localPosition = new Vector3(0f, 2.5f, 0f);

            GameObject obstacleWhiteBox = Instantiate(ResourceLoader.GetSprite(SpriteType.WHITE_BOX)) as GameObject;
            obstacle.AttachSprite(obstacleWhiteBox.GetComponent<UnitSprite>(), new Vector2(3f, 5f), OffsetType.BOTTOM_CENTER);

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