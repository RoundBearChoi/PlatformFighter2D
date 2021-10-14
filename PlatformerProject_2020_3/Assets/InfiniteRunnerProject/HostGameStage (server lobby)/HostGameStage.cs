using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RB
{
    public class HostGameStage : BaseStage
    {
        Camera _mainCam = null;

        public override void Init()
        {
            IntroCamera introCam = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.INTRO_CAMERA)) as IntroCamera;
            introCam.transform.parent = this.transform;
            
            _mainCam = introCam.GetComponent<Camera>();
            _mainCam.transform.position = new Vector3(0f, 0f, -5f);

            inputController.AddInput(UnityEngine.InputSystem.Keyboard.current, UnityEngine.InputSystem.Mouse.current, null);

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;

            _baseUI.Init(BaseUIType.HOST_GAME_UI);

            if (RB.Client.ClientManager.CURRENT != null)
            {
                Destroy(RB.Client.ClientManager.CURRENT.gameObject);
            }

            //open server
            RB.Server.ServerManager.Init();
        }

        public override void OnUpdate()
        {
            InputController.centralUserInput.OnUpdate();

            if (_baseUI != null)
            {
                _baseUI.OnUpdate();
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