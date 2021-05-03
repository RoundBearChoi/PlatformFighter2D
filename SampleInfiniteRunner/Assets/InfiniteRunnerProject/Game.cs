using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Game : MonoBehaviour
    {
        //game elements (monobehaviour)
        private Runner runner = null;

        private ResourceLoader resourceLoader = null;
        private FrameCounter frameCounter = null;
        private UserInput userInput = null;
        private CameraController cameraController = null;

        [SerializeField]
        private ObjStatsSO objStatsScriptableObj = null;

        private void Start()
        {
            objStatsScriptableObj.Init();

            frameCounter = new FrameCounter();
            userInput = new UserInput();

            resourceLoader = this.gameObject.GetComponentInChildren<ResourceLoader>();
                        
            runner = Instantiate(resourceLoader.Get(typeof(Runner))) as Runner;
            runner.Init();
            runner.SetUserInput(userInput);
            runner.SetCollisionDetector(resourceLoader.Get(typeof(CollisionDetector)) as CollisionDetector);

            runner.transform.parent = this.transform;
            runner.transform.localPosition = Vector3.zero;
            runner.transform.localRotation = Quaternion.identity;

            runner.AttachSprite(resourceLoader.GetSprite(SpriteType.RUNNER_SAMPLE));

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