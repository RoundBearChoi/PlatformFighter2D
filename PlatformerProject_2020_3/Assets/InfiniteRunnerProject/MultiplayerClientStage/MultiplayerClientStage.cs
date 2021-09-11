using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Client;
using RB.Server;

namespace RB
{
    public class MultiplayerClientStage : BaseStage
    {
        Camera _mainCam = null;

        [SerializeField]
        ClientObjects _clientObjects = null;

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

            _clientObjects = new ClientObjects();
        }

        public override void UpdateClientUnitTypes(PlayerDataset<UnitType> playerData)
        {
            if (playerData.IDAndDataCountMatch())
            {
                for (int i = 0; i < playerData.listIDs.Count; i++)
                {
                    Debugger.Log("--- received unit type: " + ((UnitType)playerData.listData[i]).ToString() + " ---");

                    ClientObject clientObj = _clientObjects.GetClientObj(playerData.listIDs[i]);

                    if (clientObj == null)
                    {
                        clientObj = _clientObjects.AddClientObj(playerData.listIDs[i]);
                    }

                    UnitCreationSpec creationSpec = BaseInitializer.current.specsGetter.GetSpec_ByUnitType(playerData.listData[i]);
                    clientObj.AddSpriteAnimations(creationSpec);
                }
            }
        }

        public override void UpdateClientPositions(PlayerDataset<PositionAndDirection> playerData)
        {
            if (playerData.IDAndDataCountMatch())
            {
                for (int i = 0; i < playerData.listIDs.Count; i++)
                {
                    ClientObject clientObj = _clientObjects.GetClientObj(playerData.listIDs[i]);
                    clientObj.SetPosition(playerData.listData[i].mPosition);
                    clientObj.UpdatePosition();


                }
            }
        }

        public override void UpdateClientSprite(int index, SpriteType spriteType)
        {
            _clientObjects.SetSpriteAnimation(index, spriteType);
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

            _clientObjects.OnFixedUpdate();

            ClearInput();
        }
    }
}