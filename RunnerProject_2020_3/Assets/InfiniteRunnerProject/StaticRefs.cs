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
        public static SwampParallax swampSpriteData;
        public static GolemSpriteData golemSpriteData;

        public static UnitCreationSpec runnerCreationSpec;
        public static UnitCreationSpec golemCreationSpec;
        public static UnitCreationSpec swamp_Grass_CreationSpec;
        public static UnitCreationSpec swamp_River_CreationSpec;
        public static UnitCreationSpec swamp_FrontTrees_CreationSpec;
        public static UnitCreationSpec swamp_BackTrees_CreationSpec;
    }
}