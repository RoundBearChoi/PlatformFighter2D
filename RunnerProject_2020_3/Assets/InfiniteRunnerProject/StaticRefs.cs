using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public static class StaticRefs
    {
        public static GameData gameData = null;
        public static MovementDustSpriteData movementDustSpriteData = null;
        public static SwampParallax swampParallaxData;

        public static List<BaseUnitCreationSpec> listCreationSpecs = new List<BaseUnitCreationSpec>();
        public static DefaultUnitCreationSpec landingDustCreationSpec = null;

        public static List<BaseUnitCreationSpec> GetSpecs<T>()
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
    }
}