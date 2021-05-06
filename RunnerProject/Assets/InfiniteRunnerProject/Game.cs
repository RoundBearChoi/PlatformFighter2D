using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Game : MonoBehaviour
    {
        private Unit _runner = null;
        private Unit _obstacle = null;
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
            
            _runner = Instantiate(ResourceLoader.Get(typeof(Runner))) as Runner;
            _runner.AttachTo(this.transform);
            _runner.unitData = new UnitData(_runner.transform);
            _runner.stateController = new StateController(StateFactory.Create_Runner_Idle(_runner.unitData, userInput));

            CollisionDetector runnerCollider = Instantiate(ResourceLoader.Get(typeof(CollisionDetector)) as CollisionDetector);
            runnerCollider.InitBoxCollider(new Vector2(2f, 3f));
            runnerCollider.transform.parent = _runner.transform;
            runnerCollider.transform.localRotation = Quaternion.identity;
            runnerCollider.transform.localPosition = new Vector3(0f, 1.5f, 0f);

            GameObject runnerSample = Instantiate(ResourceLoader.GetSprite(SpriteType.RUNNER_SAMPLE)) as GameObject;
            _runner.AttachSprite(runnerSample.GetComponent<UnitSprite>(), new Vector2(2f, 3f), OffsetType.BOTTOM_CENTER);

            _obstacle = Instantiate(ResourceLoader.Get(typeof(Obstacle))) as Obstacle;
            _obstacle.AttachTo(this.transform);
            _obstacle.unitData = new UnitData(_obstacle.transform);
            _obstacle.stateController = new StateController(StateFactory.Create_Obstacle_Idle(_obstacle.unitData));

            CollisionDetector obsCollider = Instantiate(ResourceLoader.Get(typeof(CollisionDetector)) as CollisionDetector);
            obsCollider.InitBoxCollider(new Vector2(3f, 5f));
            obsCollider.transform.parent = _obstacle.transform;
            obsCollider.transform.localRotation = Quaternion.identity;
            obsCollider.transform.localPosition = new Vector3(0f, 2.5f, 0f);

            GameObject obstacleWhiteBox = Instantiate(ResourceLoader.GetSprite(SpriteType.WHITE_BOX)) as GameObject;
            _obstacle.AttachSprite(obstacleWhiteBox.GetComponent<UnitSprite>(), new Vector2(3f, 5f), OffsetType.BOTTOM_CENTER);

            cameraController = new CameraController(_runner, FindObjectOfType<Camera>());

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

            if (_runner != null)
            {
                _runner.OnFixedUpdate();
            }

            if (_obstacle != null)
            {
                _obstacle.OnFixedUpdate();
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