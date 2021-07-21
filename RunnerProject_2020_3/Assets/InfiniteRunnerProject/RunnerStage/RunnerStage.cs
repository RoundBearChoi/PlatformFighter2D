using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerStage : Stage
    {
        private SwampSetup _swampSetup = null;

        public override void Init()
        {
            _userInput = new UserInput();
            _swampSetup = new SwampSetup();
            _swampSetup.InstantiateBaseLayer();

            InstantiateUnit_ByUnitType(UnitType.RUNNER);
            InstantiateUnits_ByUnitType(UnitType.GOLEM);

            Runner_NormalRun.initialPush = false;

            units.AddCreator(new FlatGround_Creator(this.transform));
            units.ProcessCreators();

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.GAME_UI)) as GameUI;
            _baseUI.transform.parent = this.transform;

            cameraScript = new CameraScript();
            cameraScript.SetCamera(FindObjectOfType<Camera>());
            cameraScript.SetCameraState(new Camera_FollowRunner());

            Unit runner = units.GetUnit<Runner>();
            cameraScript.SetTarget(runner.gameObject);

            _swampSetup.AddAdditionalSwamp_Grass();
            _swampSetup.AddAdditionalSwamp_Grass();
            _swampSetup.AddAdditionalSwamp_River();
            _swampSetup.AddAdditionalSwamp_River();
            _swampSetup.AddAdditionalSwamp_FrontTrees();
            _swampSetup.AddAdditionalSwamp_FrontTrees();
            _swampSetup.AddAdditionalSwamp_BackTrees();
            _swampSetup.AddAdditionalSwamp_BackTrees();
        }

        public override void OnUpdate()
        {
            _userInput.OnUpdate();
            units.OnUpdate();
            trailEffects.OnUpdate();
            cameraScript.OnUpdate();
            _baseUI.OnLateUpdate();
        }

        public override void OnFixedUpdate()
        {
            units.OnFixedUpdate();

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f5Key))
            {
                _gameIntializer.stageTransitioner.AddTransition(new RunnerStageTransition(_gameIntializer));
            }

            if (_userInput.ContainsKeyPress(UserInput.keyboard.f6Key))
            {
                _gameIntializer.stageTransitioner.AddTransition(new IntroStageTransition(_gameIntializer));
            }

            _userInput.ClearKeyDictionary();
            _userInput.ClearButtonDictionary();

            _baseUI.OnFixedUpdate();
            cameraScript.OnFixedUpdate();
        }

        public override void OnLateUpdate()
        {
            units.OnLateUpdate();
            _baseUI.OnLateUpdate();
            cameraScript.OnLateUpdate();
        }
    }
}