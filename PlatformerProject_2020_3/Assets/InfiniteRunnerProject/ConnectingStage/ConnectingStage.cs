using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Client;

namespace RB
{
    public class ConnectingStage : BaseStage
    {
        Camera _mainCam = null;
        uint _updateCount = 0;

        public override void Init()
        {
            IntroCamera introCam = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.INTRO_CAMERA)) as IntroCamera;
            introCam.transform.parent = this.transform;

            _mainCam = introCam.GetComponent<Camera>();
            _mainCam.transform.position = new Vector3(0f, 0f, -5f);

            _inputController.AddInput();
            
            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;
            _baseUI.Init(BaseUIType.CONNECTING_UI);

            //attempt connection
            ClientManager.CURRENT.ConnectToServer();

            _baseFighterClient = FindObjectOfType<ClientInput>();
            _baseFighterClient.Init();
        }

        public override void OnUpdate()
        {
            _inputController.GetLatestUserInput().OnUpdate();
            
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
            //when timed out
            _updateCount++;

            if (_updateCount > uint.MaxValue || _updateCount > 50 * 3)
            {
                RB.Network.ThreadManager.ExecuteOnMainThread(() =>
                {
                    ClientManager.CURRENT.ShowEnterIPUI();
                    ClientManager.CURRENT.QueueConnectionFailedMessage();
                });
            
                return;
            }

            //normal operations
            if (_baseUI != null)
            {
                _baseUI.OnFixedUpdate();
            }

            if (_baseFighterClient != null)
            {
                _baseFighterClient.SendInputToServer();
            }

            ClearInput();
        }
    }
}