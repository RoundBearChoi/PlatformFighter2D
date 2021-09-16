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
            if (ClientManager.CURRENT == null)
            {
                ClientManager control = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.CLIENT_MANAGER)) as ClientManager;
                ClientManager.CURRENT = control;
            }

            IntroCamera introCam = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.INTRO_CAMERA)) as IntroCamera;
            introCam.transform.parent = this.transform;

            _mainCam = introCam.GetComponent<Camera>();
            _mainCam.transform.position = new Vector3(0f, 0f, -5f);

            _inputController.AddInput();

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;
            
            _baseUI.Init(BaseUIType.ENTER_IP_UI);

            if (ClientManager.CURRENT.CONNECTION_FAILED)
            {
                Debugger.Log("prev connection attempt failed: " + ClientManager.CURRENT.GetHostIP());
            }
        }

        public override void OnUpdate()
        {
            _inputController.GetLatestUserInput().OnUpdate();

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