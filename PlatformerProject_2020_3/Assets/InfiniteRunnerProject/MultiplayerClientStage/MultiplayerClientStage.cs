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

        Unit _dummyOfflinePlayer = null;

        public override void Init()
        {
            units = new Units(this);

            _clientObjects = new ClientObjects();

            Physics2D.gravity = new Vector2(0f, BaseInitializer.current.fighterDataSO.Gravity);

            //dummy player
            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_DARK);
            _dummyOfflinePlayer = units.GetUnit<LittleRed>();
            _dummyOfflinePlayer.isDummy = true;

            _dummyOfflinePlayer.SetFighterInput(InputController.centralUserInput);

            //load level 3 (oldcity)
            GameObject levelObj = Instantiate(ResourceLoader.levelLoader.GetObj(3)) as GameObject;
            levelObj.transform.parent = this.transform;
            levelObj.transform.position = new Vector3(levelObj.transform.position.x, levelObj.transform.position.y, BaseInitializer.current.fighterDataSO.tempPlatforms_z);

            BaseInitializer.current.GetStage().InstantiateUnits_ByUnitType(UnitType.OLD_CITY);

            //set camera
            FightCamera fightCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.FIGHT_CAMERA)) as FightCamera;
            fightCamera.transform.parent = this.transform;
            Camera cam = fightCamera.GetComponent<Camera>();
            cam.orthographicSize = 10f;
            cam.transform.position = new Vector3(8f, 4.5f, BaseInitializer.current.fighterDataSO.Camera_z);

            cameraScript = new CameraScript();
            cameraScript.SetCamera(cam);
            cameraScript.SetCameraState(new Camera_LerpOnFighterXY(cameraScript, 0.08f, 0.08f, 10f, 52f, 4f), true);

            //ui
            //_baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            //_baseUI.transform.parent = this.transform;
            //_baseUI.Init(BaseUIType.FIGHT_STAGE_UI);
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

                    if (playerData.listIDs[i] == RB.Client.ClientManager.CURRENT.clientController.myId)
                    {
                        clientObj.SetDummyUnit(_dummyOfflinePlayer);
                    }
                }
            }
        }

        public override void SetTargetClientPosition(PlayerDataset<PositionAndDirection> playerData)
        {
            if (playerData.IDAndDataCountMatch())
            {
                for (int i = 0; i < playerData.listIDs.Count; i++)
                {
                    ClientObject clientObj = _clientObjects.GetClientObj(playerData.listIDs[i]);
                    clientObj.SetNetworkPosition(playerData.listData[i].mPosition);
                    clientObj.UpdateDirection(playerData.listData[i].mFacingRight);

                    if (RB.Client.ClientManager.CURRENT.clientController.myId == playerData.listIDs[i])
                    {
                        _dummyOfflinePlayer.transform.position = playerData.listData[i].mPosition;
                    }
                }
            }
        }

        public override void UpdateClientSprite(int index, SpriteType spriteType)
        {
            _clientObjects.SetSpriteAnimation(index, spriteType);
        }

        public override void OnUpdate()
        {
            InputController.centralUserInput.commands.UpdateKeyPresses();

            _clientObjects.OnUpdate();
            units.OnUpdate();
            trailEffects.OnUpdate();
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

            _dummyOfflinePlayer.unitData.spriteAnimations.GetCurrentAnimation().ToggleSpriteRenderer(false);
        }

        public override void OnFixedUpdate()
        {
            RB.Client.ClientManager.CURRENT.clientInput.SendInputToServer();

            _clientObjects.OnFixedUpdate();
            units.OnFixedUpdate();
            cameraScript.OnFixedUpdate();

            if (_baseUI != null)
            {
                _baseUI.OnFixedUpdate();
            }

            if (cameraScript.GetTarget() == null)
            {
                ClientObject myObj = _clientObjects.GetClientObj(ClientManager.CURRENT.clientController.myId);

                if (myObj != null)
                {
                    cameraScript.SetFollowTarget(myObj.GetPlayerSphere());
                }
            }
        }

        public override float GetCumulativeGravityForcePercentage()
        {
            return BaseInitializer.current.fighterDataSO.CumulativeGravityForcePercentage;
        }
    }
}