using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    [CreateAssetMenu(fileName = "Data", menuName = "InfiniteRunner/GameData/MovementDustSpriteData")]
    public class MovementDustSpriteData : ScriptableObject
    {
        public string LandingDust_SpriteName;
        public uint LandingDust_SpriteInterval = new uint();
        public Vector2 LandingDust_SpriteSize = new Vector2();

        [Space(10)]

        public string StepDust_SpriteName;
        public uint StepDust_SpriteInterval = new uint();
        public Vector2 StepDust_SpriteSize = new Vector2();
    }
}