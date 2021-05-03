using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Game : MonoBehaviour
    {
        private Runner runner = null;
        private UI ui = null;

        private FrameCounter frameCounter = null;
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
            frameCounter = new FrameCounter();
            userInput = new UserInput();

            StaticRefs.gameData = gameDataScriptableObj;

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
        }

        public void OnUpdate()
        {
            userInput.OnUpdate();
        }

        public void OnFixedUpdate()
        {
            frameCounter.OnFixedUpdate();

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