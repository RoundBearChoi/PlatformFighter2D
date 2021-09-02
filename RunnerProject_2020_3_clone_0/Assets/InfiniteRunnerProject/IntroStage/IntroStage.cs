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

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.FIGHTER_INTRO_UI)) as FighterIntroUI;
            _baseUI.transform.parent = this.transform;
        }
        
        public override void OnUpdate()
        {
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
        }
    }
}