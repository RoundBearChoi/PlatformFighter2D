using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Client;

namespace RB
{
    public class MultiplayerClientStage : BaseStage
    {
        Camera _mainCam = null;

        [SerializeField]
        ClientPositions _clientPositions = null;

        public override void Init()
        {
            IntroCamera introCam = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.INTRO_CAMERA)) as IntroCamera;
            introCam.transform.parent = this.transform;

            _mainCam = introCam.GetComponent<Camera>();
            _mainCam.transform.position = new Vector3(0f, 0f, -5f);

            _inputController.AddInput();

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;

            //_baseUI.Init(BaseUIType.CONNECTING_UI);

            _baseFighterClient = FindObjectOfType<FighterClient>();
            _baseFighterClient.Init();

            _clientPositions = new ClientPositions();
        }

        public override void UpdateClientPositions(RB.Server.PlayerDataset playerData)
        {
            if (playerData.listIDs.Count > 0)
            {
                if (playerData.listIDs.Count == playerData.listPositions.Count)
                {
                    for (int i = 0; i < playerData.listIDs.Count; i++)
                    {
                        ClientPosition cp = _clientPositions.GetClientPosition(playerData.listIDs[i]);

                        if (cp == null)
                        {
                            cp = _clientPositions.AddClientPosition(playerData.listIDs[i]);
                        }

                        cp.SetPosition(playerData.listPositions[i]);
                        cp.UpdatePosition();
                    }
                }
            }
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