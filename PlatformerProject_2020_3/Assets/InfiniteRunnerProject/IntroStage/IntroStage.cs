using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RB
{
    public class IntroStage : BaseStage
    {
        Camera _mainCam = null;

        public override void Init()
        {
            IntroCamera introCam = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.INTRO_CAMERA)) as IntroCamera;
            introCam.transform.parent = this.transform;

            _mainCam = introCam.GetComponent<Camera>();
            _mainCam.transform.position = new Vector3(0f, 0f, -5f);

            _inputController.AddInput();

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;

            _baseUI.Init(BaseUIType.FIGHTER_INTRO_UI);
        }
        
        public override void OnUpdate()
        {
            _inputController.GetLatestUserInput().OnUpdate();

            if (_inputController.GetLatestUserInput().commands.ContainsPress(CommandType.F4, true))
            {
                _gameIntializer.stageTransitioner.AddTransition(new SpriteStageTransition(_gameIntializer));
            }

            if (_inputController.GetLatestUserInput().commands.ContainsPress(CommandType.F5, true))
            {
                _gameIntializer.stageTransitioner.AddTransition(new TestStageTransition(_gameIntializer));
            }

            if (_inputController.GetLatestUserInput().commands.ContainsPress(CommandType.F6, true))
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