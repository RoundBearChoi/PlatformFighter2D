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
            if (RB.Server.ServerManager.CURRENT != null)
            {
                Destroy(RB.Server.ServerManager.CURRENT.gameObject);
            }

            ClientManager.Init();

            IntroCamera introCam = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.INTRO_CAMERA)) as IntroCamera;
            introCam.transform.parent = this.transform;

            _mainCam = introCam.GetComponent<Camera>();
            _mainCam.transform.position = new Vector3(0f, 0f, -5f);

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;
            
            _baseUI.Init(BaseUIType.ENTER_IP_UI);
        }

        public override void OnUpdate()
        {
            InputController.centralUserInput.commands.UpdateKeyPresses();

            if (_baseUI != null)
            {
                _baseUI.OnUpdate();
            }

            if (InputController.centralUserInput.commands.ContainsPress(CommandType.ENTER, true))
            {
                Debugger.Log("enter pressed");

                BaseMessage enteredMessage = new Message_HostIPEntered();
                enteredMessage.Register();
            }

            if (InputController.centralUserInput.commands.ContainsPress(CommandType.ESCAPE, true))
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
        }
    }
}