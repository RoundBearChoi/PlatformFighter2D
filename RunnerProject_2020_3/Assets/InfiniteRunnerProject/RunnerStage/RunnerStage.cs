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

        //public void AddAdditionalSwamp_Grass()
        //{
        //    Unit newGrass = InstantiateAdditionalBackgroundUnit<Swamp_Grass_DefaultState>();
        //    newGrass.iStateController.SetNewState(new Swamp_Grass_DefaultState(newGrass));
        //}
        //
        //public void AddAdditionalSwamp_River()
        //{
        //    Unit newRiver = InstantiateAdditionalBackgroundUnit<Swamp_River_DefaultState>();
        //    newRiver.iStateController.SetNewState(new Swamp_River_DefaultState(newRiver));
        //}
        //
        //public Unit InstantiateAdditionalBackgroundUnit<T>()
        //{
        //    Unit prevUnit = units.GetLatestUnitByState<T>();
        //
        //    if (prevUnit != null)
        //    {
        //        SpriteAnimation animation = prevUnit.unitData.spriteAnimations.GetLastSpriteAnimation();
        //        Sprite sprite = animation.GetSprite(0);
        //        float x = animation.gameObject.transform.localScale.x;
        //        float y = animation.gameObject.transform.localScale.y;
        //        Vector2 edge = new Vector2(sprite.bounds.size.x * x, sprite.bounds.size.y * y);
        //        Debug.DrawLine(new Vector3(10f, 50f), edge, Color.red, 3f);
        //
        //        SpriteAnimationSpec spriteSpec = prevUnit.iStateController.GetCurrentState().GetSpriteAnimationSpec();
        //        InstantiateUnit_BySpriteAnimationSpec(spriteSpec, _userInput);
        //        Unit newGrass = units.GetLatestUnitByState<T>();
        //        newGrass.transform.position = new Vector3(prevUnit.transform.position.x + edge.x, prevUnit.transform.position.y, prevUnit.transform.position.z);
        //
        //        units.AddUnit(newGrass);
        //
        //        return newGrass;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}