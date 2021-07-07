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
            units.AddCreator(new FlatGround_Creator(this.transform));
            units.AddCreator(new SwampCreator(this.transform));
            units.ProcessCreators();

            units.GetUnit<Runner>().transform.position = new Vector3(0f, 5f, 0f);
        }

        public override void OnUpdate()
        {
            _userInput.OnUpdate();
        }

        public override void OnFixedUpdate()
        {
            units.OnFixedUpdate();

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f5Key))
            {
                _gameIntializer.listStageTransitions.Add(new RunnerStageTransition(_gameIntializer));
            }

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f6Key))
            {
                _gameIntializer.listStageTransitions.Add(new IntroStageTransition(_gameIntializer));
            }

            _userInput.ClearKeyDictionary();
            _userInput.ClearButtonDictionary();
        }

        public override void OnLateUpdate()
        {
            units.OnLateUpdate();
        }
    }
}