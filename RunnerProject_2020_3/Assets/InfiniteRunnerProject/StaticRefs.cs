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

        public static List<UnitCreationSpec> listDefaultCreationSpecs = new List<UnitCreationSpec>();
    }
}