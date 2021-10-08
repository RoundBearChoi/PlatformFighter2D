using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Client;

namespace RB
{
    public class InputDevicesStage : BaseStage
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
            
            _baseUI.Init(BaseUIType.INPUT_DEVICES_STAGE_UI);
        }

        public override void OnUpdate()
        {
            _inputController.GetLatestUserInput().OnUpdate();

            if (_baseUI != null)
            {
                _baseUI.OnUpdate();
            }

            UserInput latestInput = _inputController.GetLatestUserInput();

            //if (latestInput.commands.ContainsPress(CommandType.ENTER, true))
            //{
            //    Debugger.Log("enter pressed");
            //
            //    BaseMessage enteredMessage = new Message_HostIPEntered();
            //    enteredMessage.Register();
            //}

            if (latestInput.commands.ContainsPress(CommandType.ESCAPE, true))
            {
                ReturnToMenu.Return();
            }
        }

        public override void OnLateUpdate()
        {
            if (_baseUI != null)
            {
                _baseUI.OnLateUpdate();
            }
        }

        public override void OnFixedUpdate()
        {
            if (_baseUI != null)
            {
                _baseUI.OnFixedUpdate();
            }

            _inputController.ClearAllKeysAndButtons();
        }
    }
}