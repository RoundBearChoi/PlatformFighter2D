using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Game : MonoBehaviour
    {
        private ResourceLoader resourceLoader = null;
        private FrameCounter frameCounter = null;
        private Runner runner = null;
        private UserInput userInput = null;
        private CameraController cameraController = null;

        [SerializeField]
        private ObjStatsSO objStatsScriptableObj = null;

        private void Start()
        {
            objStatsScriptableObj.Init();

            frameCounter = new FrameCounter();
            resourceLoader = this.gameObject.GetComponentInChildren<ResourceLoader>();
            userInput = this.gameObject.GetComponentInChildren<UserInput>();
            
            runner = Instantiate(resourceLoader.Get(typeof(Runner))) as Runner;
            runner.Init();
            runner.SetUserInput(userInput);
            runner.SetCollisionDetector(resourceLoader.Get(typeof(CollisionDetector)) as CollisionDetector);

            runner.transform.parent = this.transform;
            runner.transform.localPosition = Vector3.zero;
            runner.transform.localRotation = Quaternion.identity;

            runner.sampleSprite = Instantiate(resourceLoader.GetSprite(SpriteType.RUNNER_SAMPLE)) as GameObject;
            runner.sampleSprite.transform.parent = runner.transform;
            runner.sampleSprite.transform.localPosition = Vector3.zero;
            runner.sampleSprite.transform.localRotation = Quaternion.identity;

            cameraController = this.gameObject.GetComponentInChildren<CameraController>();
            cameraController.SetRunner(runner);
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