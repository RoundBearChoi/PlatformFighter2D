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
            
            Unit runner = Instantiate(ResourceLoader.Get(typeof(Runner))) as Runner;
            runner.SetParent(this.transform);
            runner.unitData = new UnitData(runner.transform);
            runner.stateController = new StateController(StateFactory.Create_Runner_Idle(runner.unitData, userInput));

            CollisionDetector runnerCollider = Instantiate(ResourceLoader.Get(typeof(CollisionDetector)) as CollisionDetector);
            runnerCollider.InitBoxCollider(new Vector2(2f, 3f));
            runnerCollider.transform.parent = runner.transform;
            runnerCollider.transform.localRotation = Quaternion.identity;
            //temp (hard coded)
            runnerCollider.transform.localPosition = new Vector3(0f, 1.5f, 0f);
            runner.collisionDetector = runnerCollider;

            GameObject runSprite = new GameObject("runner sprite animation");
            runSprite.transform.parent = runner.transform;
            runSprite.transform.localPosition = Vector3.zero;
            runSprite.transform.localRotation = Quaternion.identity;
            runner.listSpriteAnimations.Add(runSprite.AddComponent<SpriteAnimation>());
            runner.listSpriteAnimations[runner.listSpriteAnimations.Count - 1].Init(new SpriteAnimationSpecs("Texture_SampleRunAnimation", 10, new Vector2(2f, 3f), OffsetType.BOTTOM_CENTER));

            GameObject deathSprite = new GameObject("runner death animation");
            deathSprite.transform.parent = runner.transform;
            deathSprite.transform.localPosition = Vector3.zero;
            deathSprite.transform.localRotation = Quaternion.identity;
            runner.listSpriteAnimations.Add(deathSprite.AddComponent<SpriteAnimation>());
            runner.listSpriteAnimations[runner.listSpriteAnimations.Count - 1].Init(new SpriteAnimationSpecs("Texture_SampleDeathAnimation", 10, new Vector2(2f, 3f), OffsetType.BOTTOM_CENTER));

            Unit obstacle = Instantiate(ResourceLoader.Get(typeof(Obstacle))) as Obstacle;
            obstacle.SetParent(this.transform);
            obstacle.unitData = new UnitData(obstacle.transform);
            obstacle.stateController = new StateController(StateFactory.Create_Obstacle_Idle(obstacle.unitData));

            CollisionDetector obsCollider = Instantiate(ResourceLoader.Get(typeof(CollisionDetector)) as CollisionDetector);
            obsCollider.InitBoxCollider(new Vector2(1f, 1f));
            obsCollider.transform.parent = obstacle.transform;
            obsCollider.transform.localRotation = Quaternion.identity;
            //temp (hard coded)
            obsCollider.transform.localPosition = new Vector3(0f, 0.5f, 0f);

            GameObject obstacleWhiteBox = Instantiate(ResourceLoader.GetSprite(SpriteType.WHITE_BOX)) as GameObject;
            obstacle.AttachSprite(obstacleWhiteBox.GetComponent<UnitSprite>(), new Vector2(1f, 1f), OffsetType.BOTTOM_CENTER);

            GameObject cameraConObj = new GameObject("cameraController");
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