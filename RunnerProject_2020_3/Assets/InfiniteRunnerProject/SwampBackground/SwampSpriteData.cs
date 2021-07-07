using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/GameData/SwampSpriteData")]
    public class SwampSpriteData : ScriptableObject
    {
        public string Swamp_Grass_SpriteName;
        public string Swamp_River_SpriteName;
        public string Swamp_FrontTrees_SpriteName;

        [Space(10)]

        public uint Swamp_Unified_SpriteInterval = new uint();
        public Vector2 Swamp_Unified_SpriteSize = new Vector2();
    }
}