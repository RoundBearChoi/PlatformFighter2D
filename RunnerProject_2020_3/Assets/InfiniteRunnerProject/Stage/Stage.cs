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

        public virtual void InstantiateUnits<T>(UserInput userInput)
        {
            List<BaseUnitCreationSpec> specsList = StaticRefs.GetSpecs<T>();

            foreach (BaseUnitCreationSpec spec in specsList)
            {
                units.AddCreator(new DefaultUnitCreator(userInput, this.transform, spec));
            }
        }
    }
}