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
            inputController.InitCentralUserInput();

            IntroCamera introCam = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.INTRO_CAMERA)) as IntroCamera;
            introCam.transform.parent = this.transform;

            _mainCam = introCam.GetComponent<Camera>();
            _mainCam.transform.position = new Vector3(0f, 0f, -5f);

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;

            _baseUI.Init(BaseUIType.FIGHTER_INTRO_UI);

            //model stage
            BaseInitializer.CURRENT.SetModelStage(BaseStage.InstantiateNewModelStage(StageType.MODEL_FIGHT_STAGE));
        }
        
        public override void OnUpdate()
        {
            InputController.centralUserInput.commands.UpdateKeyPresses();

            if (InputController.centralUserInput.commands.ContainsPress(CommandType.F4, true))
            {
                _gameIntializer.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.SPRITE_STAGE));
            }

            if (InputController.centralUserInput.commands.ContainsPress(CommandType.F5, true))
            {
                _gameIntializer.stageTransitioner.AddNextStage(BaseStage.InstantiateNewStage(StageType.TEST_STAGE));
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

        public override void OnExit()
        {
            Destroy(BaseInitializer.CURRENT.MODEL_STAGE.gameObject);
        }
    }
}