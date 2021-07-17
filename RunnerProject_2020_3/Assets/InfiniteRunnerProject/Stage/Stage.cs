using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class Stage : MonoBehaviour
    {
        public static Stage currentStage = null;

        public Units units = new Units();

        protected GameInitializer _gameIntializer = null;
        protected UserInput _userInput = null;

        public UserInput USER_INPUT
        {
            get
            {
                return _userInput;
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

        public virtual void SetInitializer(GameInitializer gameInitializer)
        {
            _gameIntializer = gameInitializer;
        }

        public virtual void SetUserInput(UserInput userInput)
        {
            _userInput = userInput;
        }

        public virtual void InstantiateUnit(BaseUnitCreationSpec spec, UserInput userInput)
        {
            units.AddCreator(new DefaultUnitCreator(userInput, this.transform, spec));
            units.ProcessCreators();
        }

        public virtual void InstantiateUnits(List<BaseUnitCreationSpec> listSpecs, UserInput userInput)
        {
            foreach (BaseUnitCreationSpec spec in listSpecs)
            {
                units.AddCreator(new DefaultUnitCreator(userInput, this.transform, spec));
            }

            units.ProcessCreators();
        }

        public virtual void InstantiateUnit_ByUnitType(UnitType unitType, UserInput userInput)
        {
            BaseUnitCreationSpec spec = GameInitializer.current.specsGetter.GetSpec_ByUnitType(unitType);
            InstantiateUnit(spec, userInput);
        }

        public virtual void InstantiateUnits_ByUnitType(UnitType unitType, UserInput userInput)
        {
            List<BaseUnitCreationSpec> specsList = GameInitializer.current.specsGetter.GetSpecs_ByUnitType(unitType);
            InstantiateUnits(specsList, userInput);
        }

        public virtual void InstantiateUnits_BySpecType<T>(UserInput userInput)
        {
            List<BaseUnitCreationSpec> specsList = GameInitializer.current.specsGetter.GetSpecs_BySpecType<T>();
            InstantiateUnits(specsList, userInput);
        }
    }
}