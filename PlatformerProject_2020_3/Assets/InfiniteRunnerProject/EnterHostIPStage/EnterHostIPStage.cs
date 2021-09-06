using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Client;

namespace RB
{
    public class EnterHostIPStage : BaseStage
    {
        Camera _mainCam = null;

        public override void Init()
        {
            if (ClientControl.CURRENT == null)
            {
                BaseClientControl control = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.CLIENT_CONTROL)) as ClientControl;
                ClientControl.SetClientControl(control);
            }

            IntroCamera introCam = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.INTRO_CAMERA)) as IntroCamera;
            introCam.transform.parent = this.transform;

            _mainCam = introCam.GetComponent<Camera>();
            _mainCam.transform.position = new Vector3(0f, 0f, -5f);

            UserInput input = _inputController.AddInput();
            _currentInputSelection = input.INPUT_TYPE;
            _prevInputSelection = input.INPUT_TYPE;

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;
            
            _baseUI.Init(BaseUIType.ENTER_IP_UI);
        }

        public override void OnUpdate()
        {
            _inputController.GetUserInput(_currentInputSelection).OnUpdate();

            if (_baseUI != null)
            {
                _baseUI.OnUpdate();
            }

            UserInput latestInput = _inputController.GetLatestUserInput();

            if (latestInput.commands.ContainsPress(CommandType.ENTER, true))
            {
                Debugger.Log("enter pressed");

                BaseMessage enteredMessage = new Message_HostIPEntered();
                enteredMessage.Register();
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

            ClearInput();
        }
    }
}