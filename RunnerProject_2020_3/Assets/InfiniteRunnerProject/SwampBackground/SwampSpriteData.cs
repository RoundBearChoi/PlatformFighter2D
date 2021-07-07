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
        public string Swamp_BackTrees_SpriteName;
        public string Swamp_BackgroundColor_SpriteName;

        [Space(10)]

        public uint Swamp_Unified_SpriteInterval = new uint();
        public Vector2 Swamp_Unified_SpriteSize = new Vector2();

        [Space(10)]
        [Range(0f, 1f)] public float Swamp_Grass_ParallaxPercentage;
        [Range(0f, 1f)] public float Swamp_River_ParallaxPercentage;
        [Range(0f, 1f)] public float Swamp_FrontTrees_ParallaxPercentage;
        [Range(0f, 1f)] public float Swamp_BackTrees_ParallaxPercentage;
        [Range(0f, 1f)] public float Swamp_BackgroundColor_ParallaxPercentage;
    }
}