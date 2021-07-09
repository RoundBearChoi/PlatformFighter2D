using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "SwampParallax", menuName = "InfiniteRunner/GameData/SwampParallax")]
    public class SwampParallax : ScriptableObject
    {
        [Range(0f, 1f)] public float Swamp_Grass_ParallaxPercentage;
        [Range(0f, 1f)] public float Swamp_River_ParallaxPercentage;
        [Range(0f, 1f)] public float Swamp_FrontTrees_ParallaxPercentage;
        [Range(0f, 1f)] public float Swamp_BackTrees_ParallaxPercentage;
        [Range(0f, 1f)] public float Swamp_BackgroundColor_ParallaxPercentage;

        [Space(20)]
        public string Swamp_GroundTile25_SpriteName;
    }
}