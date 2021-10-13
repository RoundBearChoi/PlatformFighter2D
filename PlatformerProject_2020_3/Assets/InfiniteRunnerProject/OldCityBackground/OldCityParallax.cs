using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "OldCityParallax", menuName = "InfiniteRunner/GameData/OldCityParallax")]
    public class OldCityParallax : ScriptableObject
    {
        [Range(0f, 1f)] public float OldCity_Arches_ParallaxPercentage;
        [Range(0f, 1f)] public float OldCity_Pillars_ParallaxPercentage;
        [Range(0f, 1f)] public float OldCity_Background_ParallaxPercentage;
        [Range(0f, 1f)] public float OldCity_BottomFog_ParallaxPercentage;
    }
}