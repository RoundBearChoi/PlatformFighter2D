using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class DefaultUnitCreator
    {
        public virtual Unit InstantiateUnit(UnitCreationSpec creationSpec)
        {
            Unit unit = GameObject.Instantiate(ResourceLoader.unitLoader.GetObj(creationSpec.unitType)) as Unit;

            unit.transform.localRotation = creationSpec.localRotation;
            unit.transform.localPosition = creationSpec.localPosition;

            unit.unitData = new UnitData(unit.transform);

            return unit;
        }

        public virtual Unit DefineUnit()
        {
            return null;
        }

        public virtual void AddUnits(List<Unit> listUnits)
        {
            listUnits.Add(DefineUnit());
        }
    }
}