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

            Physics2D.gravity = new Vector2(0f, BaseInitializer.CURRENT.fighterDataSO.Gravity);

            //set camera
            FightCamera fightCamera = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.FIGHT_CAMERA)) as FightCamera;
            fightCamera.transform.parent = this.transform;
            Camera cam = fightCamera.GetComponent<Camera>();
            cam.orthographicSize = 10f;
            cam.transform.position = new Vector3(8f, 4.5f, BaseInitializer.CURRENT.fighterDataSO.Camera_z);
            _cameraScript = new CameraScript();
            _cameraScript.SetCamera(cam);

            //dummy player
            InstantiateUnit_ByUnitType(UnitType.LITTLE_RED_DARK, new LittleRed_Idle());
            _dummyOfflinePlayer = units.GetUnit<LittleRed>();
            _dummyOfflinePlayer.isDummy = true;

            _dummyOfflinePlayer.SetFighterInput(InputController.centralUserInput);
            _dummyOfflinePlayer.unitData.rigidBody2D.gravityScale = 0.15f;

            //load level 3 (oldcity)
            GameObject levelObj = Instantiate(ResourceLoader.levelLoader.GetObj(3)) as GameObject;
            levelObj.transform.parent = this.transform;
            levelObj.transform.position = new Vector3(levelObj.transform.position.x, levelObj.transform.position.y, BaseInitializer.CURRENT.fighterDataSO.tempPlatforms_z);

            InstantiateUnit_ByUnitType(UnitType.OLDCITY_BACKGROUND_TOP_FOG, new OldCity_TopFog_DefaultState());
            InstantiateUnit_ByUnitType(UnitType.OLDCITY_BACKGROUND_BOTTOM_FOG, new OldCity_BottomFog_DefaultState());
            InstantiateUnit_ByUnitType(UnitType.OLDCITY_BACKGROUND_ARCHES, new OldCity_Arches_DefaultState());
            InstantiateUnit_ByUnitType(UnitType.OLDCITY_BACKGROUND_BACKGROUND, new OldCity_Background_DefaultState());
            InstantiateUnit_ByUnitType(UnitType.OLDCITY_BACKGROUND_PILLARS, new OldCity_Pillars_DefaultState());

            //set camera targets
            _cameraScript.SetCameraState(new Camera_LerpOnFighterXY(_cameraScript, 0.08f, 0.08f, 10f, 52f, 4f), true);

            //ui
            _baseUI = Instantiate(ResourceLoader.uiLoader.GetObj(UIType.COMPATIBLE_BASE_UI)) as CompatibleBaseUI;
            _baseUI.transform.parent = this.transform;
            _baseUI.Init(BaseUIType.FIGHT_STAGE_CLIENT_UI);
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

                    UnitCreationSpec creationSpec = BaseInitializer.CURRENT.specsGetter.GetSpec_ByUnitType(playerData.listData[i]);
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
            _cameraScript.OnUpdate();

            if (_baseUI != null)
            {
                _baseUI.OnUpdate();
            }
        }

        public override void OnLateUpdate()
        {
            units.OnLateUpdate();
            _cameraScript.OnLateUpdate();

            if (_baseUI != null)
            {
                _baseUI.OnLateUpdate();
            }

            _dummyOfflinePlayer.spriteAnimations.GetCurrentAnimation().ToggleSpriteRenderer(false);
        }

        public override void OnFixedUpdate()
        {
            RB.Client.ClientManager.CURRENT.clientInput.SendInputToServer();

            _clientObjects.OnFixedUpdate();
            units.OnFixedUpdate();
            _cameraScript.OnFixedUpdate();

            if (_baseUI != null)
            {
                _baseUI.OnFixedUpdate();
            }

            if (_cameraScript.TARGET_OBJ == null)
            {
                ClientObject myObj = _clientObjects.GetClientObj(ClientManager.CURRENT.clientController.myId);

                if (myObj != null)
                {
                    _cameraScript.SetFollowTarget(myObj.GetPlayerSphere());
                }
            }
        }

        public override float GetCumulativeGravityForcePercentage()
        {
            return BaseInitializer.CURRENT.fighterDataSO.CumulativeGravityForcePercentage;
        }
    }
}