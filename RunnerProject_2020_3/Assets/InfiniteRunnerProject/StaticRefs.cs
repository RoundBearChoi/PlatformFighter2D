using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public static class StaticRefs
    {
        public static GameData gameData = null;
        public static SwampParallax swampParallaxData;

        public static List<BaseUnitCreationSpec> listCreationSpecs = new List<BaseUnitCreationSpec>();
        public static OverlapBoxCollisionData runner_overlapBoxCollisionData;

        public static List<BaseUnitCreationSpec> GetSpecs_BySpecType<T>()
        {
            List<BaseUnitCreationSpec> subList = new List<BaseUnitCreationSpec>();

            foreach(BaseUnitCreationSpec spec in listCreationSpecs)
            {
                if (spec is T)
                {
                    subList.Add(spec);
                }
            }

            return subList;
        }

        public static List<BaseUnitCreationSpec> GetSpecs_ByUnitType(UnitType unitType)
        {
            List<BaseUnitCreationSpec> subList = new List<BaseUnitCreationSpec>();

            foreach (BaseUnitCreationSpec spec in listCreationSpecs)
            {
                if (spec.unitType == unitType)
                {
                    subList.Add(spec);
                }
            }

            return subList;
        }

        public static BaseUnitCreationSpec GetSpec_ByUnitType(UnitType unitType)
        {
            for(int i = listCreationSpecs.Count - 1; i >= 0; i--)
            {
                if (listCreationSpecs[i].unitType == unitType)
                {
                    return listCreationSpecs[i];
                }
            }

            return null;
        }
    }
}