using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Game : MonoBehaviour
    {
        List<Unit> listUnits = new List<Unit>();

        private UI ui = null;

        private FixedUpdateCounter fixedUpdateCounter = new FixedUpdateCounter();
        private UpdateCounter updateCounter = new UpdateCounter();
        private UserInput userInput = new UserInput();
        
        private bool restartGame = false;
        private bool returnToIntro = false;

        [SerializeField]
        private GameData gameDataScriptableObj = null;

        public bool RestartGame()
        {
            return restartGame;
        }

        public bool ReturnToIntro()
        {
            return returnToIntro;
        }

        public void Init()
        {
            StaticRefs.gameData = gameDataScriptableObj;

            RunnerCreator runnerCreator = new RunnerCreator(userInput, this.transform);
            Unit runner = runnerCreator.GetUnit();

            Unit obstacle = Instantiate(ResourceLoader.Get(typeof(Obstacle))) as Obstacle;
            obstacle.SetParent(this.transform);
            obstacle.unitData = new UnitData(obstacle.transform);
            obstacle.stateController = new StateController(StateFactory.Create_Obstacle_Idle(obstacle.unitData));

            CollisionDetector obsCollider = Instantiate(ResourceLoader.Get(typeof(CollisionDetector)) as CollisionDetector);
            obsCollider.InitBoxCollider(new Vector2(1f, 1f));
            obsCollider.transform.parent = obstacle.transform;
            obsCollider.transform.localRotation = Quaternion.identity;
            obsCollider.transform.localPosition = StaticRefs.gameData.ObstacleBoxColliderLocalPos;

            GameObject obstacleWhiteBox = Instantiate(ResourceLoader.GetSprite(SpriteType.WHITE_BOX)) as GameObject;
            obstacle.AttachSprite(obstacleWhiteBox.GetComponent<UnitSprite>(), new Vector2(1f, 1f), OffsetType.BOTTOM_CENTER);

            GameObject cameraConObj = new GameObject("cameraController(Clone)");
            Unit cameraController = cameraConObj.AddComponent<CameraController>();
            cameraController.SetParent(this.transform);
            cameraController.stateController = new StateController(StateFactory.Create_CameraController_SimpleFollow(runner, FindObjectOfType<Camera>()));

            listUnits.Add(runner);
            listUnits.Add(obstacle);
            listUnits.Add(cameraController);

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

            foreach (Unit unit in listUnits)
            {
                unit.MatchAnimationToState();
                unit.OnFixedUpdate();
                
                if (unit.collisionDetector != null)
                {
                    bool clear = false;

                    foreach (GameObject obj in unit.collisionDetector.listCollidedGameObjects)
                    {
                        Debugger.Log(unit.gameObject.name + " detected collision");
                        unit.OnCollision();
                        clear = true;
                    }

                    if (clear)
                    {
                        unit.collisionDetector.listCollidedGameObjects.Clear();
                    }
                }
            }

            foreach(KeyPress press in userInput.listPresses)
            {
                if (press.keyCode == KeyCode.F5)
                {
                    restartGame = true;
                    returnToIntro = false;
                    break;
                }

                if (press.keyCode == KeyCode.F6)
                {
                    restartGame = false;
                    returnToIntro = true;
                    break;
                }
            }

            userInput.listPresses.Clear();
        }
    }
}