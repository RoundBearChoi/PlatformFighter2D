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

        private void Start()
        {
            frameCounter = new FrameCounter();
            resourceLoader = this.gameObject.GetComponentInChildren<ResourceLoader>();
            userInput = this.gameObject.GetComponentInChildren<UserInput>();
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
            else
            {
                runner = Instantiate(resourceLoader.Get(typeof(Runner))) as Runner;
                runner.Init();
                runner.SetUserInput(userInput);
                runner.SetCollisionDetector(resourceLoader.Get(typeof(CollisionDetector)) as CollisionDetector);

                runner.transform.parent = this.transform;
                runner.transform.localPosition = Vector3.zero;
                runner.transform.localRotation = Quaternion.identity;
            }

            userInput.listPresses.Clear();
        }
    }
}