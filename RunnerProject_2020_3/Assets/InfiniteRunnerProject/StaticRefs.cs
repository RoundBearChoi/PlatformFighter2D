using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public static class StaticRefs
    {
        public static GameData gameData = null;
        //public static RunnerMovementSpriteData runnerMovementSpriteData = null;
        //public static RunnerAttackSpriteData runnerAttackSpriteData = null;
        public static MovementDustSpriteData movementDustSpriteData = null;
        public static SwampSpriteData swampSpriteData;
        public static GolemSpriteData golemSpriteData;

        public static UnitCreationSpec runnerCreationSpec;
        public static UnitCreationSpec golemCreationSpec;
    }
}