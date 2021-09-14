using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RB.Client;
using RB.Server;

namespace RB
{
    public class MultiplayerClientStage : BaseStage
    {
        [SerializeField]
        ClientObjects _clientObjects = null;

        public override void Init()
        {
            units = new Units(this);

            //IntroCamera introCam = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.INTRO_CAMERA)) as IntroCamera;
            //introCam.transform.parent = this.transform;

            _inputController.AddInput();

            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;

            //_baseUI.Init(BaseUIType.CONNECTING_UI);

            _baseFighterClient = FindObjectOfType<FighterClient>();
            _baseFighterClient.Init();

            _clientObjects = new ClientObjects();

            BaseInitializer.current.GetStage().InstantiateUnits_ByUnitType(UnitType.OLD_CITY);

            //set camera
            FightCamera fightCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.FIGHT_CAMERA)) as FightCamera;
            fightCamera.transform.parent = this.transform;
            Camera cam = fightCamera.GetComponent<Camera>();
            cam.orthographicSize = 10f;
            cam.transform.position = new Vector3(8f, 4.5f, BaseInitializer.current.fighterDataSO.Camera_z);

            cameraScript = new CameraScript();
            cameraScript.SetCamera(cam);
            cameraScript.SetCameraState(GetStageDefaultCameraState());

            //set camera target after clientobj is instantiated
            //cameraScript.SetFollowTarget(null);
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
                    clientObj.UpdateDirection(playerData.listData[i].mFacingRight);
                }
            }
        }

        public override void UpdateClientSprite(int index, SpriteType spriteType)
        {
            _clientObjects.SetSpriteAnimation(index, spriteType);
        }

        public override void OnUpdate()
        {
            units.OnUpdate();
            _inputController.GetLatestUserInput().OnUpdate();
            cameraScript.OnUpdate();

            if (_baseUI != null)
            {
                _baseUI.OnUpdate();
            }
        }

        public override void OnLateUpdate()
        {
            units.OnLateUpdate();
            cameraScript.OnLateUpdate();

            if (_baseUI != null)
            {
                _baseUI.OnLateUpdate();
            }
        }

        public override void OnFixedUpdate()
        {
            units.OnFixedUpdate();
            _clientObjects.OnFixedUpdate();
            cameraScript.OnFixedUpdate();

            if (_baseUI != null)
            {
                _baseUI.OnFixedUpdate();
            }

            if (_baseFighterClient != null)
            {
                _baseFighterClient.SendInputToServer();
            }

            if (cameraScript.GetTarget() == null)
            {
                ClientObject myObj = _clientObjects.GetClientObj(RB.Client.Client.instance.myId);

                if (myObj != null)
                {
                    cameraScript.SetFollowTarget(myObj.GetPlayerSphere());
                }
            }

            ClearInput();
        }

        public override CameraState GetStageDefaultCameraState()
        {
            return new Camera_LerpOnTargetXAndY(0.08f, 0.08f);
        }
    }
}