using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Game : MonoBehaviour
    {
        //game elements (monobehaviour)
        private Runner runner = null;

        private FrameCounter frameCounter = null;
        private UserInput userInput = null;
        private CameraController cameraController = null;

        [SerializeField]
        private ObjStatsSO objStatsScriptableObj = null;

        private void Start()
        {
            //ResourceLoader.Init();

            objStatsScriptableObj.Init();

            frameCounter = new FrameCounter();
            userInput = new UserInput();

            runner = Instantiate(ResourceLoader.Get(typeof(Runner))) as Runner;
            runner.Init();
            runner.SetUserInput(userInput);
            runner.SetCollisionDetector(ResourceLoader.Get(typeof(CollisionDetector)) as CollisionDetector);

            runner.transform.parent = this.transform;
            runner.transform.localPosition = Vector3.zero;
            runner.transform.localRotation = Quaternion.identity;

            runner.AttachSprite(ResourceLoader.GetSprite(SpriteType.RUNNER_SAMPLE));

            cameraController = new CameraController(runner, FindObjectOfType<Camera>());
        }

        private void Update()
        {
            userInput.OnUpdate();
        }

        private void FixedUpdate()
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

            userInput.listPresses.Clear();
        }
    }
}