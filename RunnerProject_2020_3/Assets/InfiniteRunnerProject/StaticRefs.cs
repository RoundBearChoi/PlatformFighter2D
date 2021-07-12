using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public static class StaticRefs
    {
        public static List<BaseUnitCreationSpec> GetSpecs_BySpecType<T>()
        {
            List<BaseUnitCreationSpec> subList = new List<BaseUnitCreationSpec>();

            foreach(BaseUnitCreationSpec spec in GameInitializer.current.listCreationSpecsSO)
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

            foreach (BaseUnitCreationSpec spec in GameInitializer.current.listCreationSpecsSO)
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
            for(int i = GameInitializer.current.listCreationSpecsSO.Count - 1; i >= 0; i--)
            {
                if (GameInitializer.current.listCreationSpecsSO[i].unitType == unitType)
                {
                    return GameInitializer.current.listCreationSpecsSO[i];
                }
            }

            return null;
        }
    }
}