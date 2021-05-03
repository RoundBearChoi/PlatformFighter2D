using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Game : MonoBehaviour
    {
        private Runner runner = null;
        private UI ui = null;

        private FixedUpdateCounter fixedUpdateCounter = null;
        private UserInput userInput = null;
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

            fixedUpdateCounter = new FixedUpdateCounter();
            userInput = new UserInput();
            
            runner = Instantiate(ResourceLoader.Get(typeof(Runner))) as Runner;
            runner.Init();
            runner.SetUserInput(userInput);
            runner.SetCollisionDetector(ResourceLoader.Get(typeof(CollisionDetector)) as CollisionDetector);
            runner.transform.parent = this.transform;
            runner.transform.localPosition = Vector3.zero;
            runner.transform.localRotation = Quaternion.identity;

            GameObject spriteObj = Instantiate(ResourceLoader.GetSprite(SpriteType.RUNNER_SAMPLE)) as GameObject;
            runner.AttachSprite(spriteObj.GetComponent<GameElementSprite>(), OffsetType.BOTTOM_CENTER);

            cameraController = new CameraController(runner, FindObjectOfType<Camera>());

            ui = Instantiate(ResourceLoader.Get(typeof(UI))) as UI;
            ui.SetFrameCounter(fixedUpdateCounter);
            ui.transform.parent = this.transform;
            ui.transform.localPosition = Vector3.zero;
            ui.transform.localRotation = Quaternion.identity;
        }

        public void OnUpdate()
        {
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