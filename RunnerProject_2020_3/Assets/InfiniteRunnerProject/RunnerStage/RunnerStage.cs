using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class RunnerStage : Stage
    {
        public override void Init()
        {
            _userInput = new UserInput();

            InstantiateUnit_ByUnitType(UnitType.RUNNER);
            InstantiateUnits_ByUnitType(UnitType.GOLEM);

            units.AddCreator(new FlatGround_Creator(this.transform));
            units.ProcessCreators();

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.GAME_UI)) as GameUI;
            _baseUI.transform.parent = this.transform;

            cameraScript = new CameraScript();
            cameraScript.SetCamera(FindObjectOfType<Camera>());
            cameraScript.SetCameraState(new Camera_FollowRunner());
            cameraScript.SetTarget(units.GetUnit<Runner>().gameObject);

            backgroundSetup = new SwampSetup();
            backgroundSetup.InstantiateBaseLayer();
            //backgroundSetup.AddAdditionalBackground<Swamp_Grass_DefaultState>();
            //backgroundSetup.AddAdditionalBackground<Swamp_Grass_DefaultState>();
            //backgroundSetup.AddAdditionalBackground<Swamp_River_DefaultState>();
            //backgroundSetup.AddAdditionalBackground<Swamp_River_DefaultState>();
            //backgroundSetup.AddAdditionalBackground<Swamp_FrontTrees_DefaultState>();
            //backgroundSetup.AddAdditionalBackground<Swamp_FrontTrees_DefaultState>();
            //backgroundSetup.AddAdditionalBackground<Swamp_BackTrees_DefaultState>();
            //backgroundSetup.AddAdditionalBackground<Swamp_BackTrees_DefaultState>();
        }

        public override void OnUpdate()
        {
            _userInput.OnUpdate();
            _baseUI.OnUpdate();
            units.OnUpdate();
            trailEffects.OnUpdate();
            cameraScript.OnUpdate();
            
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
            _baseUI.OnLateUpdate();
            units.OnLateUpdate();
            cameraScript.OnLateUpdate();
        }
    }
}