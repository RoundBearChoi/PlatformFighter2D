using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GameStage : Stage
    {
        List<Unit> _listUnits = new List<Unit>();

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

            //ObstacleCreator obstacleCreator = new ObstacleCreator(this.transform);
            //Unit obstacle = obstacleCreator.GetUnit();

            CameraControllerCreator cameraCreator = new CameraControllerCreator(this.transform, runner, FindObjectOfType<Camera>());
            Unit cameraController = cameraCreator.GetUnit();

            ObstaclePlacerCreator opCreator = new ObstaclePlacerCreator(runner, this);
            Unit placer = opCreator.GetUnit();

            _listUnits.Add(runner);
            //_listUnits.Add(obstacle);
            _listUnits.Add(cameraController);
            _listUnits.Add(placer);

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

            for (int i = _listUnits.Count - 1; i >= 0; i--)
            {
                _listUnits[i].MatchAnimationToState();
                _listUnits[i].OnFixedUpdate();

                if (_listUnits[i].collisionDetector != null)
                {
                    bool clear = false;

                    foreach (GameObject obj in _listUnits[i].collisionDetector.listCollidedGameObjects)
                    {
                        Debugger.Log(_listUnits[i].gameObject.name + " detected collision");
                        _listUnits[i].OnCollision();
                        clear = true;
                    }

                    if (clear)
                    {
                        _listUnits[i].collisionDetector.listCollidedGameObjects.Clear();
                    }
                }
            }

            //foreach (Unit unit in _listUnits)
            //{
            //    unit.MatchAnimationToState();
            //    unit.OnFixedUpdate();
            //
            //    if (unit.collisionDetector != null)
            //    {
            //        bool clear = false;
            //
            //        foreach (GameObject obj in unit.collisionDetector.listCollidedGameObjects)
            //        {
            //            Debugger.Log(unit.gameObject.name + " detected collision");
            //            unit.OnCollision();
            //            clear = true;
            //        }
            //
            //        if (clear)
            //        {
            //            unit.collisionDetector.listCollidedGameObjects.Clear();
            //        }
            //    }
            //}

            foreach (KeyPress press in userInput.listPresses)
            {
                if (press.keyCode == KeyCode.F5)
                {
                    nextStage = typeof(GameStage);
                    break;
                }

                if (press.keyCode == KeyCode.F6)
                {
                    nextStage = typeof(IntroStage);
                    break;
                }
            }

            userInput.listPresses.Clear();
        }

        public void AddUnit(Unit unit)
        {
            _listUnits.Add(unit);
        }
    }
}