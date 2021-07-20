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

            InstantiateUnit_ByUnitType(UnitType.RUNNER, _userInput);
            InstantiateUnits_ByUnitType(UnitType.SWAMP, null);
            InstantiateUnits_ByUnitType(UnitType.GOLEM, null);

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

            //testing repeating background
            Unit prevGrass = units.GetLatestUnitByState<Swamp_Grass_DefaultState>();

            SpriteAnimation animation = prevGrass.unitData.spriteAnimations.GetLastSpriteAnimation();
            Sprite sprite = animation.GetSprite(0);
            float x = animation.gameObject.transform.localScale.x;
            float y = animation.gameObject.transform.localScale.y;
            Vector2 edge = new Vector2(sprite.bounds.size.x * x, sprite.bounds.size.y * y);
            Debug.DrawLine(new Vector3(10f, 50f), edge, Color.red, 3f);

            SpriteAnimationSpec spriteSpec = prevGrass.iStateController.GetCurrentState().GetSpriteAnimationSpec();
            InstantiateUnit_BySpriteAnimationSpec(spriteSpec, _userInput);
            Unit newGrass = units.GetLatestUnitByState<Swamp_Grass_DefaultState>();
            newGrass.transform.position = new Vector3(prevGrass.transform.position.x + edge.x, prevGrass.transform.position.y, prevGrass.transform.position.z);

            newGrass.iStateController.SetNewState(new Swamp_Grass_DefaultState(newGrass));
            units.AddUnit(newGrass);
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