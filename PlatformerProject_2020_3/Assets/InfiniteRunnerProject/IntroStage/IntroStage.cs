using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RB
{
    public class IntroStage : BaseStage
    {
        Keyboard _keyboard = null;
        Camera _mainCam = null;

        public override void Init()
        {
            _keyboard = Keyboard.current;

            IntroCamera introCam = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.INTRO_CAMERA)) as IntroCamera;
            introCam.transform.parent = this.transform;

            _mainCam = introCam.GetComponent<Camera>();
            _mainCam.transform.position = new Vector3(0f, 0f, -5f);

            UserInput input = _inputController.AddInput();
            _currentInputSelection = input.INPUT_TYPE;
            _prevInputSelection = input.INPUT_TYPE;

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;

            _baseUI.Init(BaseUIType.FIGHTER_INTRO_UI);
        }
        
        public override void OnUpdate()
        {
            _inputController.GetUserInput(_currentInputSelection).OnUpdate();

            //if (_keyboard.enterKey.wasPressedThisFrame)
            //{
            //    _gameIntializer.stageTransitioner.AddTransition(new FightStageTransition(_gameIntializer));
            //}

            if (_keyboard.f4Key.wasPressedThisFrame)
            {
                _gameIntializer.stageTransitioner.AddTransition(new SpriteStageTransition(_gameIntializer));
            }

            if (_keyboard.f5Key.wasPressedThisFrame)
            {
                _gameIntializer.stageTransitioner.AddTransition(new TestStageTransition(_gameIntializer));
            }

            if (_keyboard.f6Key.wasPressedThisFrame)
            {
                _gameIntializer.stageTransitioner.AddTransition(new RunnerStageTransition(_gameIntializer));
            }

            _baseUI.OnUpdate();
        }

        public override void OnLateUpdate()
        {
            _baseUI.OnLateUpdate();
        }

        public override void OnFixedUpdate()
        {
            _baseUI.OnFixedUpdate();

            ClearInput();
        }
    }
}