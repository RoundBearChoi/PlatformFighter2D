using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerStage : Stage
    {
        private UserInput _userInput = new UserInput();

        public override void Init()
        {
            units.AddCreator(new Runner_Creator(_userInput, this.transform));
            units.ProcessCreators();

            //runner must already be in the list
            units.AddCreator(new CameraController_Creator(this.transform, units.GetUnit<Runner>(), FindObjectOfType<Camera>()));
            units.ProcessCreators();
        }

        public override void OnUpdate()
        {
            _userInput.OnUpdate();
        }

        public override void OnFixedUpdate()
        {
            units.OnFixedUpdate();
        }

        public override void OnLateUpdate()
        {
            units.OnLateUpdate();
        }
    }
}