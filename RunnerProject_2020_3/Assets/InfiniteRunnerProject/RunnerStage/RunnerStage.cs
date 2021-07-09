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
            units.AddCreator(new DefaultUnitCreator(_userInput, this.transform, StaticRefs.runnerCreationSpec));
            units.ProcessCreators();

            Unit runner = units.GetUnit<Runner>();
            runner.SetUserInput(_userInput);
            Runner_NormalRun.initialPush = false;

            units.AddCreator(new CameraController_Creator(this.transform, runner, FindObjectOfType<Camera>()));
            units.AddCreator(new DefaultUnitCreator(null, this.transform, StaticRefs.golemCreationSpec));
            units.AddCreator(new DefaultUnitCreator(null, this.transform, StaticRefs.swamp_Grass_CreationSpec));
            units.AddCreator(new DefaultUnitCreator(null, this.transform, StaticRefs.swamp_River_CreationSpec));
            units.AddCreator(new DefaultUnitCreator(null, this.transform, StaticRefs.swamp_FrontTrees_CreationSpec));
            units.AddCreator(new DefaultUnitCreator(null, this.transform, StaticRefs.swamp_BackTrees_CreationSpec));
            units.AddCreator(new FlatGround_Creator(this.transform));

            units.ProcessCreators();

            //temp
            Unit golem = units.GetUnit<Golem>();
            golem.attackData = new AttackData();
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