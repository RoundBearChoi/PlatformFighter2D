using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class BaseStage : MonoBehaviour
    {
        public Units units = null;
        public TrailEffects trailEffects = new TrailEffects();
        public IBackgroundSetup backgroundSetup = null;
        public IBackgroundSetup groundSetup = null;

        protected BaseInitializer _gameIntializer = null;
        protected CameraScript _cameraScript = null;

        [SerializeField]
        protected BaseUI _baseUI = null;

        [SerializeField]
        public InputController inputController;

        public static BaseStage InstantiateNewStage(StageType stageType)
        {
            LoadStageObjs(stageType);

            BaseStage newStage = GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(stageType)) as BaseStage;

            newStage.SetInitializer(BaseInitializer.CURRENT);
            newStage.transform.parent = BaseInitializer.CURRENT.transform;
            newStage.transform.localPosition = new Vector3(0f, 0f, 0f);
            newStage.transform.localRotation = Quaternion.identity;

            return newStage;
        }

        public static BaseStage InstantiateNewModelStage(StageType stageType)
        {
            LoadStageObjs(stageType);

            BaseStage modelStage = GameObject.Instantiate(ResourceLoader.stageLoader.GetObj(stageType)) as BaseStage;

            modelStage.SetInitializer(BaseInitializer.CURRENT);
            modelStage.Init();

            return modelStage;
        }

        public static void LoadStageObjs(StageType stageType)
        {
            if (stageType == StageType.TEST_STAGE)
            {
                ResourceLoader.LoadRunnerStage();
            }
            else if (
                stageType == StageType.FIGHT_STAGE ||
                stageType == StageType.MODEL_FIGHT_STAGE ||
                stageType == StageType.MULTIPLAYER_SERVER_STAGE ||
                stageType == StageType.MULTIPLAYER_CLIENT_STAGE)
            {
                ResourceLoader.LoadFightStage();
            }
        }

        public CameraScript CAMERA_SCRIPT
        {
            get
            {
                return _cameraScript;
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

        public virtual void OnExit()
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

        public virtual UserInput GetUserInputByClientIndex(int clientIndex)
        {
            return null;
        }

        public virtual void SetInitializer(BaseInitializer gameInitializer)
        {
            _gameIntializer = gameInitializer;
        }

        public virtual void InstantiateUnit(UnitCreationSpec spec, UnitState firstState)
        {
            units.AddCreator(new UnitCreator(this.transform, spec, firstState));
            units.ProcessCreators(this);
        }

        public virtual void InstantiateUnit_ByUnitType(UnitType unitType, UnitState firstState)
        {
            UnitCreationSpec spec = BaseInitializer.CURRENT.specsGetter.GetSpec_ByUnitType(unitType);
            InstantiateUnit(spec, firstState);
        }

        public virtual float GetCumulativeGravityForcePercentage()
        {
            return 0f;
        }
    }
}