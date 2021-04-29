using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Game : MonoBehaviour
    {
        private FrameCounter frameCounter = null;
        private Runner runner = null;
        private UserInput userInput = null;

        private void Start()
        {
            frameCounter = new FrameCounter();
            userInput = this.gameObject.GetComponentInChildren<UserInput>();
            runner = this.gameObject.GetComponentInChildren<Runner>();
            runner.SetUserInput(userInput);
        }

        private void Update()
        {
            userInput.OnUpdate();
        }

        private void FixedUpdate()
        {
            frameCounter.OnFixedUpdate();
            runner.OnFixedUpdate();
        }
    }
}