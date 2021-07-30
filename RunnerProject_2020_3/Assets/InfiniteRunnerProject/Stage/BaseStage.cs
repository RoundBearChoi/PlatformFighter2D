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

        protected GameInitializer _gameIntializer = null;

        [SerializeField]
        protected UserInput _userInput = null;

        [SerializeField]
        protected BaseUI _baseUI = null;

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

        public virtual void SetInitializer(GameInitializer gameInitializer)
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
            UnitCreationSpec spec = GameInitializer.current.specsGetter.GetSpec_ByUnitType(unitType);
            InstantiateUnit(spec);
        }

        public virtual void InstantiateUnit_BySpriteType(SpriteType spriteType)
        {
            UnitCreationSpec creationSpec = GameInitializer.current.specsGetter.GetSpec_BySpriteType(spriteType);
            InstantiateUnit(creationSpec);
        }

        public virtual void InstantiateUnits_ByUnitType(UnitType unitType)
        {
            List<UnitCreationSpec> specsList = GameInitializer.current.specsGetter.GetSpecs_ByUnitType(unitType);
            InstantiateUnits(specsList);
        }

        public virtual void InstantiateUnits_BySpecType<T>()
        {
            List<UnitCreationSpec> specsList = GameInitializer.current.specsGetter.GetSpecs_BySpecType<T>();
            InstantiateUnits(specsList);
        }

        public virtual float GetCumulativeGravityForcePercentage()
        {
            return 0f;
        }
    }
}