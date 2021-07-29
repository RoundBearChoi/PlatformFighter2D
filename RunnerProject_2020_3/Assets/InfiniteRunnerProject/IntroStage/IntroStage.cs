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

            GameCamera gameCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.GAME_CAMERA)) as GameCamera;
            gameCamera.transform.parent = this.transform;

            _mainCam = gameCamera.GetComponent<Camera>();
            _mainCam.transform.position = new Vector3(0f, 0f, -5f);

            Application.targetFrameRate = 80;
        }
        
        public override void OnUpdate()
        {
            if (_keyboard.enterKey.wasPressedThisFrame)
            {
                _gameIntializer.stageTransitioner.AddTransition(new RunnerStageTransition(_gameIntializer));
            }

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
                _gameIntializer.stageTransitioner.AddTransition(new FightStageTransition(_gameIntializer));
            }
        }
    }
}