using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class BaseStage : MonoBehaviour
    {
        public Units units = null;
        public TrailEffects trailEffects = new TrailEffects();
        public CameraScript cameraScript = null;
        public IBackgroundSetup backgroundSetup = null;
        public IBackgroundSetup groundSetup = null;
        public BaseNPCSetup npcSetup = null;

        protected BaseInitializer _gameIntializer = null;

        [SerializeField]
        protected BaseUI _baseUI = null;

        [SerializeField]
        protected InputController _inputController = null;

        public static BaseStage InstantiateNewStage(StageType stageType)
        {
            LoadStageObjs(stageType);

            BaseStage newStage = GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(stageType)) as BaseStage;

            newStage.SetInitializer(BaseInitializer.current);
            newStage.transform.parent = BaseInitializer.current.transform;
            newStage.transform.localPosition = new Vector3(0f, 0f, 0f);
            newStage.transform.localRotation = Quaternion.identity;

            return newStage;
        }

        public static void LoadStageObjs(StageType stageType)
        {
            if (stageType == StageType.RUNNER_STAGE ||
                stageType == StageType.TEST_STAGE
                )
            {
                ResourceLoader.LoadRunnerStage();
            }
            else if (
                stageType == StageType.FIGHT_STAGE ||
                stageType == StageType.MULTIPLAYER_SERVER_STAGE ||
                stageType == StageType.MULTIPLAYER_CLIENT_STAGE)
            {
                ResourceLoader.LoadFightStage();
            }
        }

        public virtual void Init()
        {

        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void OnLateUpdate()
        {

        }

        public virtual void UpdateClientUnitTypes(RB.Server.PlayerDataset<UnitType> playerData)
        {

        }

        public virtual void SetTargetClientPosition(RB.Server.PlayerDataset<RB.Server.PositionAndDirection> playerData)
        {

        }

        public virtual void UpdateClientSprite(int index, SpriteType spriteType)
        {

        }

        public virtual CameraState GetStageDefaultCameraState()
        {
            return null;
        }

        public virtual UserInput GetUserInputByClientIndex(int clientIndex)
        {
            return null;
        }

        public virtual void SetInitializer(BaseInitializer gameInitializer)
        {
            _gameIntializer = gameInitializer;
        }

        public virtual void InstantiateUnit(UnitCreationSpec spec)
        {
            units.AddCreator(new DefaultUnitCreator(this.transform, spec));
            units.ProcessCreators();
        }

        public virtual void InstantiateUnits(List<UnitCreationSpec> listSpecs)
        {
            foreach (UnitCreationSpec spec in listSpecs)
            {
                units.AddCreator(new DefaultUnitCreator(this.transform, spec));
            }

            units.ProcessCreators();
        }

        public virtual void InstantiateUnit_ByUnitType(UnitType unitType)
        {
            UnitCreationSpec spec = BaseInitializer.current.specsGetter.GetSpec_ByUnitType(unitType);
            InstantiateUnit(spec);
        }

        public virtual void InstantiateUnit_BySpriteType(SpriteType spriteType)
        {
            UnitCreationSpec creationSpec = BaseInitializer.current.specsGetter.GetSpec_BySpriteType(spriteType);
            InstantiateUnit(creationSpec);
        }

        public virtual void InstantiateUnits_ByUnitType(UnitType unitType)
        {
            List<UnitCreationSpec> specsList = BaseInitializer.current.specsGetter.GetSpecs_ByUnitType(unitType);
            InstantiateUnits(specsList);
        }

        public virtual void InstantiateUnits_BySpecType<T>()
        {
            List<UnitCreationSpec> specsList = BaseInitializer.current.specsGetter.GetSpecs_BySpecType<T>();
            InstantiateUnits(specsList);
        }

        public virtual float GetCumulativeGravityForcePercentage()
        {
            return 0f;
        }

        public InputController GetInputController()
        {
            return _inputController;
        }
    }
}