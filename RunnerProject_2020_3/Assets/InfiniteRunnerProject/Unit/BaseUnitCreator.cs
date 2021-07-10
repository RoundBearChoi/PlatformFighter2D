using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public abstract class BaseUnitCreator
    {
        protected UserInput _userInput = null;
        protected Transform _parentTransform = null;
        protected BaseUnitCreationSpec _creationSpec = null;

        public virtual Unit InstantiateUnit(BaseUnitCreationSpec creationSpec)
        {
            Unit unit = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(creationSpec.unitType)) as Unit;

            unit.transform.localRotation = creationSpec.localRotation;
            unit.transform.localPosition = creationSpec.localPosition;

            return unit;
        }

        public virtual Unit DefineUnit()
        {
            return null;
        }

        public abstract void AddUnits(List<Unit> listUnits);
    }
}